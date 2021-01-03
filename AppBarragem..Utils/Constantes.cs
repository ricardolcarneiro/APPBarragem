using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace AppBarragem.Utils
{
    public static class Constantes
    {
        public static string UniqueClaimTypeIdentifier { get; set; }
        public static string PEDIDO { get; set; }

        //public static string URL_IMAGEM = @"http://localhost:55751/Content/Imagem/";
        public static string URL_IMAGEM = @"http://www.gesconv.com.br/appbarragem/Content/Imagem/";
        public static string IDENTITY_UUID = "ApplicationCookie";
        public static string USER_LOCAL_IMAGEM;
    
        // Flag para configurar o PagarMe em modo teste
        public const bool MODO_TESTE = true;

 // só testar agora



        public static Nullable<T> ToNullable<T>(this string s) where T : struct
        {
            Nullable<T> result = new Nullable<T>();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)conv.ConvertFrom(s);
                }
            }
            catch { }
            return result;
        }


        public static string SHA1Encode(string to_encrypt)
        {
            try
            {
                return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(to_encrypt))).Replace("-", string.Empty);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string TratarCupom(int intTipoCupom)
        {
            switch (intTipoCupom.GetHashCode())
            {
                case (int)AppBarragem.Utils.TipoCupom.Real:
                    return "Real";
                case (int)AppBarragem.Utils.TipoCupom.Percentual:
                    return "Percentual";
                
                default:
                    return "";
            }
        }

        public static string TratarStatus(int intStatus)
        {
            switch (intStatus.GetHashCode())
            {
                case (int)TipoPedido.Solicitado:
                    return "Solicitado";
                case (int)TipoPedido.EmAndamento:
                    return "EmAndamento";
                case (int)TipoPedido.Pronto:
                    return "Pronto";
                case (int)TipoPedido.Atrasado:
                    return "Atrasado";
                case (int)TipoPedido.ACaminho:
                    return "ACaminho";
                case (int)TipoPedido.Entregue:
                    return "Entregue";
                case (int)TipoPedido.Cancelado:
                    return "Cancelado";
                default:
                    return "";
            }
        }

        public static string TratarStatusCadastro(int intStatusCadastro)
        {
            switch (intStatusCadastro.GetHashCode())
            {
                case (int)StatusCadastro.Aprovado:
                    return "Aprovado";
                case (int)StatusCadastro.EmAnalise:
                    return "Em Analise";
                case (int)StatusCadastro.Recusado:
                    return "Recusado";        
                default:
                    return "";
            }
        }

        public static string TratarTipoUsuario(int intStatus)
        {
            switch (intStatus.GetHashCode())
            {
                case (int)TipoUsuario.SuperAdmin:
                    return "Super Administrador";
                case (int)TipoUsuario.Admin:
                    return "Administrador";
                case (int)TipoUsuario.User:
                    return "Usuário";
                case (int)TipoUsuario.Entregador:
                    return "Entregador";
              
                default:
                    return "";
            }
        }
        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

    }
}