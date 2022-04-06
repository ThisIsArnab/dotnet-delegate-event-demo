// namespace dotnetDelegateEvents // Default namespace is global
// {
    public class ParameterPassing
    {
        public void FormatText(ref string text){
            if(!string.IsNullOrEmpty(text)) {
                text += " [is FORMATTED parameter pass by ref]";
            }
        }
    }
// }