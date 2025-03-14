﻿using Kingsland.MofParser.Ast;
using Kingsland.MofParser.Lexing;
using Kingsland.MofParser.Objects;
using Kingsland.MofParser.Parsing;
using Kingsland.MofParser.Source;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kingsland.MofParser
{

   

    public static class PowerShellDscHelper
    {

        public static void ParseMofFileInstances(string filename)
        {

            // read the text from the mof file
            var sourceText = File.ReadAllText(filename);

            // turn the text into a stream of characters for lexing
            var reader = SourceReader.From(sourceText);

            // lex the characters into a sequence of tokens
            var tokens = Lexer.Lex(reader);

            // parse the tokens into an ast tree
            var ast = Parser.Parse(tokens);

            // scan the ast for any "instance" definitions and convert them
            /*            var instances = ((MofSpecificationAst)ast).Productions
                                                                  .Where(p => (p is InstanceValueDeclarationAst))
                                                                  .Cast<InstanceValueDeclarationAst>()
                                                                  .Select(Instance.FromAstNode)
                                                                  .ToList();*/

            var classes = ((MofSpecificationAst)ast).Productions
                                          .Where(p => (p is ClassDeclarationAst))
                                          .Cast<ClassDeclarationAst>()
                                          .ToList();

            foreach(var cc in classes)
            {
                System.Console.WriteLine(cc.ClassName);
            }


            // return the result
            //return instances.ToList();

        }

    }

}
