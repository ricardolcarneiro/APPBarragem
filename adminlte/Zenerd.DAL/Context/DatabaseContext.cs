
// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning



namespace ZeNerd.DAL.Context
{




    using System.Linq;



    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]

    public class DatabaseContext : System.Data.Entity.DbContext, IDatabaseContext
    {

        public System.Data.Entity.DbSet<AspNetRoles> AspNetRoles { get; set; }



        public System.Data.Entity.DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }



        public System.Data.Entity.DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }



        public System.Data.Entity.DbSet<AspNetUsers> AspNetUsers { get; set; }



        public System.Data.Entity.DbSet<GrupoUsuario> GrupoUsuario { get; set; }



        public System.Data.Entity.DbSet<Menu> Menu { get; set; }



        public System.Data.Entity.DbSet<Morador> Morador { get; set; }



        public System.Data.Entity.DbSet<RotaDestino> RotaDestino { get; set; }



        public System.Data.Entity.DbSet<RotaFuga> RotaFuga { get; set; }



        public System.Data.Entity.DbSet<TipoDomicilio> TipoDomicilio { get; set; }



        public System.Data.Entity.DbSet<TipoEducacao> TipoEducacao { get; set; }



        public System.Data.Entity.DbSet<TipoEspecieDomicilioOcupado> TipoEspecieDomicilioOcupado { get; set; }



        public System.Data.Entity.DbSet<TipoEtinoRacial> TipoEtinoRacial { get; set; }



        public System.Data.Entity.DbSet<TipoFalaLinguaIndigena> TipoFalaLinguaIndigena { get; set; }



        public System.Data.Entity.DbSet<TipoLinguaPortuquesa> TipoLinguaPortuquesa { get; set; }



        public System.Data.Entity.DbSet<TipoParantesco> TipoParantesco { get; set; }



        public System.Data.Entity.DbSet<TipoPessoaIndigena> TipoPessoaIndigena { get; set; }



        public System.Data.Entity.DbSet<TipoQuilombolas> TipoQuilombolas { get; set; }



        public System.Data.Entity.DbSet<TipoRegistroCivil> TipoRegistroCivil { get; set; }



        public System.Data.Entity.DbSet<TipoSexo> TipoSexo { get; set; }



        public System.Data.Entity.DbSet<Usuario> Usuario { get; set; }



        public System.Data.Entity.DbSet<Usuarioold> Usuarioold { get; set; }




        static DatabaseContext()
        {

            System.Data.Entity.Database.SetInitializer<DatabaseContext>(null);

        }


        public DatabaseContext()
            : base("Name=DatabaseContext")
        {

        }


        public DatabaseContext(string connectionString)
            : base(connectionString)
        {

        }

        public DatabaseContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {

        }

        public DatabaseContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public DatabaseContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {

        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }


        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Configurations.Add(new AspNetRolesConfiguration());

            modelBuilder.Configurations.Add(new AspNetUserClaimsConfiguration());

            modelBuilder.Configurations.Add(new AspNetUserLoginsConfiguration());

            modelBuilder.Configurations.Add(new AspNetUsersConfiguration());

            modelBuilder.Configurations.Add(new GrupoUsuarioConfiguration());

            modelBuilder.Configurations.Add(new MenuConfiguration());

            modelBuilder.Configurations.Add(new MoradorConfiguration());

            modelBuilder.Configurations.Add(new RotaDestinoConfiguration());

            modelBuilder.Configurations.Add(new RotaFugaConfiguration());

            modelBuilder.Configurations.Add(new TipoDomicilioConfiguration());

            modelBuilder.Configurations.Add(new TipoEducacaoConfiguration());

            modelBuilder.Configurations.Add(new TipoEspecieDomicilioOcupadoConfiguration());

            modelBuilder.Configurations.Add(new TipoEtinoRacialConfiguration());

            modelBuilder.Configurations.Add(new TipoFalaLinguaIndigenaConfiguration());

            modelBuilder.Configurations.Add(new TipoLinguaPortuquesaConfiguration());

            modelBuilder.Configurations.Add(new TipoParantescoConfiguration());

            modelBuilder.Configurations.Add(new TipoPessoaIndigenaConfiguration());

            modelBuilder.Configurations.Add(new TipoQuilombolasConfiguration());

            modelBuilder.Configurations.Add(new TipoRegistroCivilConfiguration());

            modelBuilder.Configurations.Add(new TipoSexoConfiguration());

            modelBuilder.Configurations.Add(new UsuarioConfiguration());

            modelBuilder.Configurations.Add(new UsuariooldConfiguration());


        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {

            modelBuilder.Configurations.Add(new AspNetRolesConfiguration(schema));

            modelBuilder.Configurations.Add(new AspNetUserClaimsConfiguration(schema));

            modelBuilder.Configurations.Add(new AspNetUserLoginsConfiguration(schema));

            modelBuilder.Configurations.Add(new AspNetUsersConfiguration(schema));

            modelBuilder.Configurations.Add(new GrupoUsuarioConfiguration(schema));

            modelBuilder.Configurations.Add(new MenuConfiguration(schema));

            modelBuilder.Configurations.Add(new MoradorConfiguration(schema));

            modelBuilder.Configurations.Add(new RotaDestinoConfiguration(schema));

            modelBuilder.Configurations.Add(new RotaFugaConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoDomicilioConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoEducacaoConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoEspecieDomicilioOcupadoConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoEtinoRacialConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoFalaLinguaIndigenaConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoLinguaPortuquesaConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoParantescoConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoPessoaIndigenaConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoQuilombolasConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoRegistroCivilConfiguration(schema));

            modelBuilder.Configurations.Add(new TipoSexoConfiguration(schema));

            modelBuilder.Configurations.Add(new UsuarioConfiguration(schema));

            modelBuilder.Configurations.Add(new UsuariooldConfiguration(schema));


            return modelBuilder;
        }

    }

}
// </auto-generated>