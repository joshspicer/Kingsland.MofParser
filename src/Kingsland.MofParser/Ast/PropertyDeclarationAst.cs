﻿using Kingsland.MofParser.CodeGen;
using Kingsland.MofParser.Tokens;
using System;

namespace Kingsland.MofParser.Ast
{

    /// <summary>
    /// </summary>
    /// <remarks>
    ///
    /// See https://www.dmtf.org/sites/default/files/standards/documents/DSP0221_3.0.1.pdf
    ///
    /// 7.5.5 Property declaration
    ///
    ///     propertyDeclaration          = [ qualifierList ] ( primitivePropertyDeclaration /
    ///                                    complexPropertyDeclaration /
    ///                                    enumPropertyDeclaration /
    ///                                    referencePropertyDeclaration) ";"
    ///
    ///     primitivePropertyDeclaration = primitiveType propertyName [ array ]
    ///                                    [ "=" primitiveTypeValue]
    ///
    ///     complexPropertyDeclaration   = structureOrClassName propertyName [ array ]
    ///                                    [ "=" ( complexTypeValue / aliasIdentifier ) ]
    ///
    ///     enumPropertyDeclaration      = enumName propertyName [ array ]
    ///                                    [ "=" enumTypeValue]
    ///
    ///     referencePropertyDeclaration = classReference propertyName [ array ]
    ///                                    [ "=" referenceTypeValue ]
    ///
    ///     array                        = "[" "]"
    ///     propertyName                 = IDENTIFIER
    ///     structureOrClassName         = IDENTIFIER
    ///
    ///     classReference               = DT_REFERENCE
    ///     DT_REFERENCE                 = className REF
    ///     REF                          = "ref" ; keyword: case insensitive
    ///
    public sealed class PropertyDeclarationAst : AstNode, IStructureFeatureAst
    {

        #region Builder

        public sealed class Builder
        {

            public QualifierListAst QualifierList
            {
                get;
                set;
            }

            public IdentifierToken ReturnType
            {
                get;
                set;
            }

            public IdentifierToken ReturnTypeRef
            {
                get;
                set;
            }

            public IdentifierToken PropertyName
            {
                get;
                set;
            }

            public bool ReturnTypeIsArray
            {
                get;
                set;
            }

            public PropertyValueAst Initializer
            {
                get;
                set;
            }

            public PropertyDeclarationAst Build()
            {
                return new PropertyDeclarationAst(
                    this.QualifierList,
                    this.ReturnType,
                    this.ReturnTypeRef,
                    this.PropertyName,
                    this.ReturnTypeIsArray,
                    this.Initializer
                );
            }

        }

        #endregion

        #region Constructors

        private PropertyDeclarationAst(
            QualifierListAst qualifierList,
            IdentifierToken returnType,
            IdentifierToken returnTypeRef,
            IdentifierToken propertyName,
            bool returnTypeIsArray,
            PropertyValueAst initializer
        )
        {
            this.QualifierList = qualifierList ?? new QualifierListAst.Builder().Build();
            this.ReturnType = returnType ?? throw new ArgumentNullException(nameof(returnType));
            this.ReturnTypeRef = returnTypeRef;
            this.PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            this.ReturnTypeIsArray = returnTypeIsArray;
            this.Initializer = initializer;
        }

        #endregion

        #region Properties

        public QualifierListAst QualifierList
        {
            get;
            private set;
        }

        public IdentifierToken ReturnType
        {
            get;
            private set;
        }

        public bool ReturnTypeIsRef
        {
            get
            {
                return (this.ReturnTypeRef != null);
            }
        }

        public IdentifierToken ReturnTypeRef
        {
            get;
            private set;
        }

        public IdentifierToken PropertyName
        {
            get;
            private set;
        }

        public bool ReturnTypeIsArray
        {
            get;
            private set;
        }

        public PropertyValueAst Initializer
        {
            get;
            private set;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return AstMofGenerator.ConvertPropertyDeclarationAst(this);
        }

        #endregion

    }

}
