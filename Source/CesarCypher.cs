using System;


namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public void ExcecaoCaracterEspecial(int letra)
        {
            if ((letra >= 33 && letra <= 47) || (letra >= 58 && letra <= 64) ||
                (letra >= 91 && letra <= 96) || (letra >= 123 && letra <= 255))
            {
                throw new ArgumentOutOfRangeException();
            }

        }
        
        public string Crypt(string message)
        {
            if (message == null) throw new ArgumentNullException();
            string textoParaCriptografar = message.ToLower();
            string textoCriptografado = "";
            int letraCriptografar;
            int cifragemCesar = 3;


            for (int i = 0; i < textoParaCriptografar.Length; i++)
            {
                //Convert.ToInt32 faz a conversão de string para int;
                letraCriptografar = Convert.ToInt32(textoParaCriptografar[i]);

                ExcecaoCaracterEspecial(letraCriptografar);


                if (letraCriptografar > 96 && letraCriptografar < 123)
                {
                    letraCriptografar = letraCriptografar + cifragemCesar;

                    if (letraCriptografar > 122)
                    {
                        letraCriptografar = letraCriptografar - 26;
                    }
                }
                textoCriptografado += Convert.ToChar(letraCriptografar);
            }
            return textoCriptografado;
        }
        
        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null) throw new ArgumentNullException();
            string textoParaDescriptografar = cryptedMessage.ToLower();
            string textoDescriptografado = "";
            int letraDescriptografar;
            int cifragemCesar = 3;
            

            for (int i = 0; i < textoParaDescriptografar.Length; i++)
                {
                
                letraDescriptografar = Convert.ToInt32(textoParaDescriptografar[i]);

                ExcecaoCaracterEspecial(letraDescriptografar);

                if (letraDescriptografar > 96 && letraDescriptografar < 123) 
                {
                    letraDescriptografar = letraDescriptografar - cifragemCesar;
                        
                    if (letraDescriptografar < 97)
                    {
                        letraDescriptografar = letraDescriptografar + 26;
                    }

                }
                textoDescriptografado += Convert.ToChar(letraDescriptografar);
             }
             return textoDescriptografado;
            
        }
    }
}

