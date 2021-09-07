using NatSuite.Recorders;
using NatSuite.Recorders.Clocks;
using NatSuite.Recorders.Inputs;
using NatSuite.Sharing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCamController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header(@"Recording")]
    //Camera in the scene to recording
    [SerializeField]
    private Camera videoCameraUI; // This is a GameObject with Camera Component and disable the UI layer in Culling Mask 
    public int videoWidth = 720;
    public bool recordMicrophone;


    private MP4Recorder recorder;
    private CameraInput cameraInput;
    private AudioInput audioInput;
    private AudioSource microphoneSource;

    private IClock clock;


    private IEnumerator Start() {

        //Start Camera AR to Recording
        //videoCameraUI = Camera.main;

        // Start microphone
        microphoneSource = gameObject.AddComponent<AudioSource>();
        microphoneSource.mute =
        microphoneSource.loop = true;
        microphoneSource.bypassEffects =
        microphoneSource.bypassListenerEffects = false;
        microphoneSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
        yield return new WaitUntil(() => Microphone.GetPosition(null) > 0);
        microphoneSource.Play();
    }
    private void OnDestroy()
    {
        // Stop microphone
        microphoneSource.Stop();
        Microphone.End(null);
    }
    #region --Recording--

    public void StartRecording()
    {
        // Compute the video width dynamically to match the screen's aspect ratio
        var videoHeight = (int)(videoWidth / videoCameraUI.aspect);
        videoHeight = videoHeight >> 1 << 1; // Ensure divisible by 2
                                             // Create recorder and camera input

        // Start recording
        var frameRate = 30;
        var sampleRate = recordMicrophone ? AudioSettings.outputSampleRate : 0;
        var channelCount = recordMicrophone ? (int)AudioSettings.speakerMode : 0;

        clock = new RealtimeClock();
        recorder = new MP4Recorder(videoWidth, videoHeight, frameRate, sampleRate, channelCount);
        // Create recording inputs
        cameraInput = new CameraInput(recorder, clock, Camera.main);
        audioInput = recordMicrophone ? new AudioInput(recorder, clock, microphoneSource, true) : null;
        // Unmute microphone
        microphoneSource.mute = audioInput == null;

    }

    public async void StopRecording()
    {
        // Stop camera input and recorder
        // Mute microphone
        microphoneSource.mute = true;
        // Stop recording
        audioInput?.Dispose();
        cameraInput.Dispose();
        var path = await recorder.FinishWriting();
        // Playback recording
        Debug.Log($"Saved recording to: {path}");
        //Handheld.PlayFullScreenMovie($"file://{path}");

        //Share Video
        // And present the share sheet


#if UNITY_EDITOR
        return;
#else 
        var payload = new SharePayload();
        payload.AddMedia(path);
        payload.Commit();
#endif

    }
    #endregion


}
