
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





    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]

    public class TipoQuilombolas
    {


        public int Id { get; set; }

        public string Nome { get; set; }






        public virtual System.Collections.Generic.ICollection<Morador> Morador { get; set; }




        public TipoQuilombolas()
        {


            Morador = new System.Collections.Generic.List<Morador>();
        }

    }



}
// </auto-generated>
