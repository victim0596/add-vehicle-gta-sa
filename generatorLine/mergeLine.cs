using addVehicle.Const;
using addVehicle.Model;
using log4net;
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
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool mergeAndSave(IList<Generator> listGenerator, Info info)
        {
            log.Info("Started generation of loader.txt file");
            string templateLoader = template.templateLoader;
            foreach (Generator generator in listGenerator) 
            {
                string toReplace = "{" + generator.fileAnalized + "}";
                templateLoader = templateLoader.Replace(toReplace, generator.line);
            }
            log.Info("loader.txt content generation completed.");
            #region save on modloader folder
            log.Info("Starting saving content of loader.txt in that file");
            try
            {
                File.WriteAllText($"{info.modFolder}\\loader.txt", templateLoader);
                log.Info("loader.txt file generated successfully.");
            }
            catch (Exception ex) 
            {
                log.Error($"Error on saving loader.txt. Error:{ex.Message}");
                return false;
            }
            #endregion
            return true;
        }
    }
}
