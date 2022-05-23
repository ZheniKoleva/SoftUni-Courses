namespace _01.Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => @"
<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

    }
}
