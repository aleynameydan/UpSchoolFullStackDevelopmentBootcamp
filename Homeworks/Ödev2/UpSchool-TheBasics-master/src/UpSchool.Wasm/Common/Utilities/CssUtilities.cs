namespace UpSchool.Wasm.Common.Utilities;

//static class uygulama başladığında bir kere üretilen ve newlemeden kullandığımız classlardır
public static class CssUtilities
{
    public static string GetCssColourClassForPasswords(int length)
    {
        switch (length)
        {
            case var value when (value >=6 && value <= 12):
                return  "bg-danger";
                
                
            case var value when (value >=13 && value <=19):
                return  "bg-warning";
                
                
            case var value when (value >=20 && value<=40):
                return  "bg-success";
                

            default:
                throw new Exception("Beklenmedik password uzunluğu geldi.");
                break;
        }
    }
}