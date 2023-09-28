using System.Text.RegularExpressions;

namespace PasswordValidator;

public class PasswordValidator
{
    public static bool IsValid(string password)
    {

        /*
         (?=.*[a-z]) verifica si hay al menos una letra minúscula.
         (?=.*[A-Z]) verifica si hay al menos una letra mayúscula.
         (?=.*\d) verifica si hay al menos un dígito numérico.
         (?=.*[_]) verifica si hay al menos una barra baja
          .{8,} verifica si la longitud de la cadena es al menos 8.
         */
        return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[_]).{8,}$");
    }
}