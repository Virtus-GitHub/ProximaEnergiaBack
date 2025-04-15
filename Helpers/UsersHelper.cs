using ProximaEnergia.Enums;
using ProximaEnergia.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProximaEnergia.Helpers
{
    public static class UsersHelper
    {
        public static UsersEnum GetUser(string user)
        {
            return user switch
            {
                "davidvirtus@gmail.com" => UsersEnum.Virtus,
                "jorgeperez@proximaenergia.com" => UsersEnum.Jorge,
                "usuariopruebas@testing.com" => UsersEnum.Pruebas,
                _ => throw new CustomException($"El usuario {user} no tiene acceso.", nameof(GetUser))
            };
        }
    }
}
