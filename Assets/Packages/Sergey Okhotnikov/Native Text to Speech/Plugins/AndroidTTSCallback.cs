namespace NativeTextToSpeech
{
    public interface AndroidTTSCallback
    {
        void onFinish();
        void onError(string error);
    }
}
