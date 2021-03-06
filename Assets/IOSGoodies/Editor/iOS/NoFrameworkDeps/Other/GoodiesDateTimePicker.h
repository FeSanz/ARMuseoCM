#import <Foundation/Foundation.h>
#import "BridgeGoodisFunctionDefs.h"

NS_ASSUME_NONNULL_BEGIN

@interface GoodiesDateTimePicker : NSObject {
	void *_callbackPtr;
	OnDateSelectedDelegate *_onDateSelectedDelegate;
	void *_cancelPtr;
	ActionVoidCallbackDelegate *_onCancelDelegate;
	int _datePickerType;
	int _minuteInterval;
	NSDate *_initialDateTime;

	UIButton *_blockerButton;
	UIDatePicker *_datePicker;
	UIToolbar *_toolbar;
}

- (id)initWithCallbackPtr:(void *)callbackPtr
   onDateSelectedDelegate:(OnDateSelectedDelegate *)onDateSelectedDelegate
              onCancelPtr:(void *)onCancelPtr
         onCancelDelegate:(ActionVoidCallbackDelegate *)onCancelDelegate
           datePickerType:(int)datePickerType
           minuteInterval:(int)minuteInterval;

- (void)setInitialValuesWithYear:(int)year
                           month:(int)month
                             day:(int)day
                            hour:(int)hour
                          minute:(int)minute;

- (void)setInitialValueToNow;

- (void)showPicker;

- (void)showPickerWithMinDate:(NSDate *)minDate
                      MaxDate:(NSDate *)maxDate;
@end

NS_ASSUME_NONNULL_END
