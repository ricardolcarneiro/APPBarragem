using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppBarragem.Utils
{
    public enum TipoCupom
    {
        Real,
        Percentual
    }

    public enum TipoRecuperarSenha
    {
        Cliente,
        Entregador
    }

    public enum TipoUsuario
    {
        SuperAdmin,
        Admin,
        User,
        Entregador
    }

    public enum TipoPedido
    {
        Solicitado,

        [Display(Name = "Em andamento", Description = "Em andamento")]
        [Description("Em andamento")]
        EmAndamento,
        Pronto,
        Atrasado,
        [Display(Name = "A caminho", Description = "A caminho")]
        [Description("A caminho")]
        ACaminho,
        Entregue,
        Cancelado
    }

    public enum TipoPagamento
    {
        Crédito,
        Débito,
        Dinheiro
    }

    public enum TipoUnidade
    {
        Kg,
        G,
        L,
        Unidade
    }

    public enum TipoEstoque
    {
        Principal,
        Cozinha,
        Bar
    }

    public enum TipoMovimentacao
    {
        Recebimentos,
        Fixa,
        Variaveis,
        Pessoas,
        Impostos,
        Transferências
    }

    public enum Pago
    {
        NAo,
        Sim
    }

    public enum StatusCadastro
    {
        EmAnalise,
        Aprovado,
        Recusado
    }

    public enum TIPO_ESPECIE_DOMICILIO
    {
        [Display(Name = "1 - DOMICILIO PARTICULAR PERMANENTE OCUPADO", Description = "1 - DOMICILIO PARTICULAR PERMANENTE OCUPADO")]
        [Description("1 - DOMICILIO PARTICULAR PERMANENTE OCUPADO")]
        DOMICILIO_PARTICULAR_PERMANENTE_OCUPADO,
        [Display(Name = "5 - DOMICILIO PARTICULAR IMPROVISADO OCUPADO", Description = "5 - DOMICILIO PARTICULAR IMPROVISADO OCUPADO")]
        [Description("5 - DOMICILIO PARTICULAR IMPROVISADO OCUPADO")]
        DOMICILIO_PARTICULAR_IMPROVISADO_OCUPADO,
        [Display(Name = "6 - DOMICILIO COLETIVO COM MORADOR", Description = "6 - DOMICILIO COLETIVO COM MORADOR")]
        [Description("6 - DOMICILIO COLETIVO COM MORADOR")]
        DOMICILIO_COLETIVO,
    }

    public enum TIPO_DOMICILIO
    {

        CASA,
        CASA_DE_VILA_OU_EM_CONDOMINIO,
        APARTAMENTO,
        HABITACAO_EM_CASA_DE_COMODOS_OU_CORTICO,
        HABITACAO_INDIGENA_SEM_PAREDES_OU_MALOCA,
        ESTRUTURA_RESIDENCIAL_PERMANENTE_DEGRADADA_OU_INACABADA,
        TENDA_OU_BARRACA_DE_LONA, _PLASTICO_OU_TECIDO,
        DENTRO_DO_ESTABELECIMENTO_EM_FUNCIONAMENTO,
        OUTROS_ABRIGOS_NATURAIS_E_OUTRAS_ESTRUTURAS_IMPROVISADAS,
        ESTRUTURA_IMPROVISADA_EM_LOGRADOURO_PÚBLICO, _EXCETO_TENDA_OU_BARRACA,
        ESTRUTURA_NAO_RESIDENCIAL_PERMANENTE_DEGRADADA_OU_INACABADA,
        VEICULOS_CARROS_CAMINHÕES_TRAILERS_BARCOS_ETC,
        ASILO_OU_OUTRA_INSTITUICAO_DE_LONGA_PERMANÊNCIA_PARA_IDOSOS,
        HOTEL_OU_PENSAO,
        ALOJAMENTO,
        PENITENCIARIA_CENTRO_DE_DETENCAO_E_SIMILAR,
        OUTRO,
        ABRIGO_ALBERGUE_OU_CASA_DE_PASSAGEM_PARA_POPULACAO_EM_SITUACAO_DE_RUA,
        ABRIGO_CASAS_DE_PASSAGEM_OU_REPÚBLICA_ASSISTENCIAL,
        OUTROS_GRUPOS_VULNERAVEIS,
        CLINICA_PSIQUIATRICA_COMUNIDADE_TERAPÊUTICA_E_SIMILAR,
        ORFANATO_E_SIMILAR,
        UNIDADE_DE_INTERNACAO_DE_MENORES,
        QUARTEL_OU_OUTRA_ORGANIZACAO_MILITAR
    }

    public enum TIPO_SEXO
    {

        MASCULINO,
        FEMININO
    }
    public enum TIPO_PARENTESCO
    {

        PESSOA_RESPONSAVEL_PELO_DOMICILIO,
        GENRO_OU_NORA,
        PAI, _MAE, _PADRASTO_OU_MADRASTA,
        SOGRO_A_,
        NETO_A_,
        ENTEADO_A_,
        IRMAO_OU_IRMA,
        AVO_OU_AVO,
        OUTRO_PARENTE,
        AGREGADO_A_,
        BISNETO_A_,
        PENSIONISTA,
        EMPREGADO_A__DOMESTICO_A_,
        PARENTE_DO_A__EMPREGADO_A__DOMESTICO_A_,
        INDIVIDUAL_EM_DOMICILIO_COLETIVO

    }

    public enum TIPO_ETINIA_RACIAL
    {
        BRANCA,
        PRETA,
        AMARELA,
        PARDA,
        INDIGENA,
    }

    public enum TIPO_PESSOA_INDIGENA
    {
        SIM,
        NÃO
    }

    public enum TIPO_FALA_INDIGENA
    {
        SIM,
        NÃO
    }


    public enum TIPO_FALA_PORTUGUES
    {
        SIM,
        NÃO
    }

    public enum TIPO_QUILOMBOLAS
    {
        SIM,
        NÃO
    }
    public enum TIPO_REGISTRO_CIVIL
    {
        DO_CARTORIO,
        DECLARACAO_DE_NASCIDO_VIVO_DNV_DO_HOSPITAL_OU_DA_MATERNIDADE,
        REGISTRO_ADMINISTRATIVO_DE_NASCIMENTO_INDIGENA_RANI,
        NAO_TEM,
        NAO_SABE
    }

    public enum TIPO_EDUCACAO
    {
        SIM,
        NÃO
    }
}