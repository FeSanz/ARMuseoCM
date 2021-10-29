using System;
using NatSuite.Recorders;
using NatSuite.Recorders.Clocks;
using NatSuite.Recorders.Inputs;
using NatSuite.Sharing;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ARCamController : MonoBehaviour
{
    [Header(@"Recording")]
    [SerializeField, Tooltip("Camara para grabar")]
    private Camera aRCamera;
    
    public int videoWidth = 720;
    public bool recordMicrophone;


    private MP4Recorder _recorder;
    private CameraInput _cameraInput;
    private AudioInput _audioInput;
    private AudioSource _microphoneSource;

    private IClock _clock;


    private IEnumerator Start() {
        // Iniciar microfono
        _microphoneSource = gameObject.AddComponent<AudioSource>();
        _microphoneSource.mute =
        _microphoneSource.loop = true;
        _microphoneSource.bypassEffects =
        _microphoneSource.bypassListenerEffects = false;
        _microphoneSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
        yield return new WaitUntil(() => Microphone.GetPosition(null) > 0);
        _microphoneSource.Play();
    }
    private void OnDestroy()
    {
        // Apagar microfono
        _microphoneSource.Stop();
        Microphone.End(null);
    }

    /// <summary>
    /// Inicia grabacion de escena
    /// </summary>
    public void StartRecording()
    {
        //Calcule el ancho del video de forma dinámica para que coincida con la relación de aspecto de la pantalla
        var videoHeight = (int)(videoWidth / aRCamera.aspect);
        // Asegurarse que sea divisible por 2, crear entrada de cámara y grabadora
        videoHeight = videoHeight >> 1 << 1; 

        // Iniciar grabacion
        var frameRate = 30;
        var sampleRate = recordMicrophone ? AudioSettings.outputSampleRate : 0;
        var channelCount = recordMicrophone ? (int)AudioSettings.speakerMode : 0;

        _clock = new RealtimeClock();
        _recorder = new MP4Recorder(videoWidth, videoHeight, frameRate, sampleRate, channelCount);
        // Crear entradas de grabación
        _cameraInput = new CameraInput(_recorder, _clock, Camera.main);
        _audioInput = recordMicrophone ? new AudioInput(_recorder, _clock, _microphoneSource, true) : null;
        // Unmute microphone
        _microphoneSource.mute = _audioInput == null;
    }

    /// <summary>
    /// Detener grabación
    /// </summary>
    public async void StopRecording()
    {
        // Silenciar microfono
        _microphoneSource.mute = true;
        // Detener grabacion
        _audioInput?.Dispose();
        _cameraInput.Dispose();
        //Ruta en caso de guardar el video
        var path = await _recorder.FinishWriting();
        Debug.Log($"Saved recording to: {path}");
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        
        

#if UNITY_EDITOR
        return;
        #else 
        var payload = new SharePayload();
        payload.AddMedia(path);
        payload.Commit();
        #endif
    }
}
