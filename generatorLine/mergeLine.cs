using addVehicle.Const;
using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace addVehicle.generatorLine
{
    public class MergeLine
    {
        public bool mergeAndSave(IList<Generator> listGenerator, Info info)
        {
            string templateLoader = template.templateLoader;
            foreach (Generator generator in listGenerator) 
            {
                string toReplace = "{" + generator.fileAnalized + "}";
                templateLoader = templateLoader.Replace(toReplace, generator.line);
            }
            #region save on modloader folder
            File.WriteAllText($"{info.modFolder}\\loader.txt", templateLoader);
            #endregion
            return true;
        }
    }
}
