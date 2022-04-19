using System.Collections.Generic;

namespace VendaVeiculos.Shared
{
    public class Global
    {
        public enum SituacaoVeiculo
        {
            Novo = 1,
            SemiNovo,
            Usado
        }

        public static class MensagemCampo
        {
            public const string CAMPO_DUPLICADO = "Valor informado já registrado";
            public const string CAMPO_OBRIGATORIO = "Campo obrigatório";
            public const string CAMPO_INVALIDO = "Valor inválido para o campo";
            public const string EMAIL_INVALIDO = "Informe um endereço de email válido";
            public const string SENHA_INCORRETA = "Falha ao comparar senhas";
        }

        public static class Notificacao
        {
            public enum Tipo 
            { 
                Sucesso,
                Falha,
                Aviso, 
                Informacao
            }

            public const string ERRO_CADASTRO = "Ocorreu uma falha durante o cadastro, tente novamente.";
            public const string ERRO_EDICAO = "Ocorreu uma falha a edição do registro, tente novamente.";
            public const string ERRO_REMOCAO = "Ocorreu uma falha ao remover registro, tente novamente.";

            public const string SUCESSO_CADASTRO = "Cadastro realizado com sucesso.";
            public const string SUCESSO_EDICAO = "Registro atualizado com sucesso.";
            public const string SUCESSO_REMOCAO = "Registro removido com sucesso.";
        }

        public static Dictionary<int, string> ListarCombustivel()
        {
            return new Dictionary<int, string>
            {
                {1, "Elétrico"},
                {2, "Etanol"},
                {3, "Diesel"},
                {4, "Gasolina"},
                {5, "Híbrido"}
            };
        }

        public static Dictionary<string, string> ListarEstados()
        {
            return new Dictionary<string, string>
            {
                {"AC", "Acre"},
                {"AL", "Alagoas"},
                {"AP", "Amapá"},
                {"AM", "Amazonas"},
                {"BA", "Bahia"},
                {"CE", "Ceará"},
                {"DF", "Distrito Federal"},
                {"ES", "Espírito Santo"},
                {"GO", "Goiás"},
                {"MA", "Maranhão"},
                {"MT", "Manto Grosso"},
                {"MS", "Mato Grosso do Sul"},
                {"MG", "Minas Gerais"},
                {"PA", "Pará"},
                {"PB", "Paraíba"},
                {"PR", "Paraná"},
                {"PE", "Pernambuco"},
                {"PI", "Piauí"},
                {"RJ", "Rio de Janeiro"},
                {"RN", "Rio Grande do Norte"},
                {"RS", "Rio Grande do Sul"},
                {"RO", "Rondônia"},
                {"RR", "Roraima"},
                {"SC", "Santa Catarina"},
                {"SP", "São Paulo"},
                {"SE", "Sergipe"},
                {"TO", "Tocantins"}
            };
        }

        public static Dictionary<int, string> ListarSituacaoVeiculo()
        {
            return new Dictionary<int, string>
            {
                {1, "Novo"},
                {2, "Semi-novo"},
                {3, "Usado"},
            };
        }

        public static Dictionary<int, string> ListarTipoVeiculo()
        {
            return new Dictionary<int, string>
            {
                {1, "Carro"},
                {2, "Moto"}
            };
        }
    }
}
