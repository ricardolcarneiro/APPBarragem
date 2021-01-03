namespace AppBarragem.Utils
{
    public struct Token
    {
        public const string API = "e6971e61-824a-4c1e-a6df-86a54c56bea4-ae7b57ef-1e1c-4059-a48c-5c4c970edddd-f9dbbf74-9403-4819-a3d0-d4ae442db2d4";
        //public const string TestApiKey = "ak_test_zQDG2nfLgLCZYgpRhrcocN26vGhdqy";
        //public const string TestEncryptionKey = "ek_test_hNl0mjzZD7HUmpJt6yhvCDRVEuLHAG";

        public const string LiveApiKey = "ak_live_iG9c0IzclxO4IvNotPvbKHs4XYADRm";
        public const string LiveEncryptionKey = "ek_live_fOwBrmghtCSATUULi5EW7AQY4Y7bMX";
    }

    public struct URL
    {
        public const string CRIAR_CARTAO = "https://api.pagar.me/1/cards";
        public const string API = "http://api.mamelukos.com.br/";
        //public const string API = "http://192.168.0.104:61111/";
    }

    public struct Suporte
    {
        public const string Email = "suporte@mamelukos.com.br";
        public const string Senha = "fG35@14cS";
        public const string Host = "mail.mamelukos.com.br";
        public const int Porta = 8889;
        public const bool SSL = false;
    }

    public struct Rotas
    {
        public struct Auth
        {
            /* Cliente */
            public const string LOGIN_CLIENTE = "auth/login_cliente/";
            public const string LOGOUT_CLIENTE = "auth/logout_cliente/";
            public const string CRIAR_CADASTRO_CLIENTE = "auth/criar_cadastro_cliente/";
            public const string EDITAR_CADASTRO_CLIENTE = "auth/editar_cadastro_cliente/";
            public const string RECUPERAR_SENHA_CLIENTE = "auth/recuperar_senha_cliente/";

            /* Entregador */
            public const string CRIAR_CADASTRO_ENTREGADOR = "auth/criar_cadastro_entregador/";
            public const string LOGIN_ENTREGADOR = "auth/login_entregador/";
            public const string RECUPERAR_SENHA_ENTREGADOR = "auth/recuperar_senha_entregador/";
        }

        public struct Home
        {
            /* Cliente */
            public const string BUSCAR_DESTAQUES = "home/buscar_destaques/";
            public const string BUSCAR_TODAS_PRACAS = "home/buscar_todas_pracas/";
            public const string BUSCAR_PRACA = "home/buscar_praca/";
            public const string BUSCAR_TODAS_CATEGORIAS = "home/buscar_todas_categorias/";
            public const string BUSCAR_CATEGORIA = "home/buscar_categoria/";
            public const string BUSCAR_TODOS_PRODUTOS = "home/buscar_todos_produtos/";
            public const string BUSCAR_TODOS_PRODUTOS_FILTRO = "home/buscar_todos_produtos_filtro/";
            public const string BUSCAR_TOP_PRODUTOS = "home/buscar_top_produtos/";
            public const string BUSCAR_PRODUTO = "home/buscar_produto/";
            public const string BUSCAR_CONFIGURACAO = "home/buscar_configuracao/";
            public const string CRIAR_CARTAO_PAGAR_ME = "home/criar_cartao_pagar_me/";
            public const string BUSCAR_CARTAO_PAGAR_ME = "home/buscar_cartao_pagar_me/";
            public const string DELETAR_CARTAO_PAGAR_ME = "home/deletar_cartao_pagar_me/";
            public const string ENVIAR_PEDIDO = "home/enviar_pedido/";
            public const string BUSCAR_TODOS_PEDIDOS = "home/buscar_todos_pedidos/";
            public const string BUSCAR_TODOS_PEDIDOS_SEM_ID = "home/BuscarTodosPedidosSemId/";
            public const string BUSCAR_PEDIDO = "home/buscar_pedido/";
            public const string AVALIAR_PEDIDO = "home/avaliar_pedido/";
            public const string AVALIAR_PRODUTO = "home/avaliar_produto/";
            public const string BUSCAR_LOCALIZACAO_PEDIDO = "home/buscar_localizacao_pedido/";
            public const string CANCELAR_PEDIDO = "home/cancelar_pedido/";
            public const string BUSCAR_CUPOM = "home/buscar_cupom/";
            public const string BUSCAR_TODOS_CLIENTES = "home/buscar_todos_clientes/";

            /* Entregador */
            public const string BUSCAR_ENTREGA = "home/buscar_entrega/";
            public const string ENVIAR_LOCALIZACAO = "home/enviar_localizacao/";
            public const string CONCLUIR_ENTREGA = "home/concluir_entrega/";
            public const string BUSCAR_MINHAS_ENTREGAS = "home/buscar_minhas_entregas/";


        }
    }
}