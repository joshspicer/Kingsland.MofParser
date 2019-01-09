using Kingsland.MofParser.CodeGen;
using Kingsland.MofParser.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kingsland.MofParser.Ast
{

    /// <summary>
    /// </summary>
    /// <remarks>
    ///
    /// See https://www.dmtf.org/sites/default/files/standards/documents/DSP0221_3.0.1.pdf
    ///
    /// 7.5.2 Class declaration
    ///
    ///     classDeclaration = [ qualifierList ] CLASS className [ superClass ]
    ///                        "{" *classFeature "}" ";"
    ///
    ///     className        = elementName
    ///     superClass       = ":" className
    ///     classFeature     = structureFeature /
    ///                        methodDeclaration
    ///
    ///     CLASS            = "class" ; keyword: case insensitive
    ///
    /// </remarks>
    public sealed class ClassDeclarationAst : MofProductionAst
    {

        #region Builder

        public sealed class Builder
        {

            public Builder()
            {
                this.Features = new List<IClassFeatureAst>();
            }

            public QualifierListAst Qualifiers
            {
                get;
                set;
            }

            public IdentifierToken ClassName
            {
                get;
                set;
            }

            public IdentifierToken SuperClass
            {
                get;
                set;
            }

            public List<IClassFeatureAst> Features
            {
                get;
                set;
            }

            public ClassDeclarationAst Build()
            {
                return new ClassDeclarationAst(
                    this.Qualifiers,
                    this.ClassName,
                    this.SuperClass,
                    new ReadOnlyCollection<IClassFeatureAst>(
                        this.Features ?? new List<IClassFeatureAst>()
                    )
                );
            }

        }

        #endregion

        #region Constructors

        public ClassDeclarationAst(QualifierListAst qualifiers, IdentifierToken className, IdentifierToken superClass, ReadOnlyCollection<IClassFeatureAst> features)
        {
            this.Qualifiers = qualifiers ?? new QualifierListAst.Builder().Build();
            this.ClassName = className ?? throw new ArgumentNullException(nameof(className));
            this.SuperClass = superClass;
            this.Features = features ?? new ReadOnlyCollection<IClassFeatureAst>(new List<IClassFeatureAst>());
        }

        #endregion

        #region Properties

        public QualifierListAst Qualifiers
        {
            get;
            private set;
        }

        public IdentifierToken ClassName
        {
            get;
            private set;
        }

        public IdentifierToken SuperClass
        {
            get;
            private set;
        }

        public ReadOnlyCollection<IClassFeatureAst> Features
        {
            get;
            private set;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return MofGenerator.ConvertClassDeclarationAst(this);
        }

        #endregion

    }

}
