//
//  TTS.h
//  TextToSpeechIOS
//
//  Created by Sergey Okhotnikov on 8/5/22.
//

NS_ASSUME_NONNULL_BEGIN

typedef void (*StringDelegateCallback)(const char * string);
typedef void (*VoidDelegateCallback)();

@interface TaskHolder : NSObject

@property VoidDelegateCallback onFinish;
@property StringDelegateCallback onError;

- (void) finish:() value;
- (void) error:(const char *) value;

@end
NS_ASSUME_NONNULL_END
