using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Storage
{
    /// <summary>
    /// Permet de sauvegarder la couche métier via fichier JSON
    /// </summary>
    public class JSONStorage
    {
        private string fileName;
        private DataContractJsonSerializer ser;

        /// <summary>
        /// Initialise l'objet
        /// </summary>
        /// <param name="fileName">le nom (et chemin complet) du fichier de sauvegarde</param>
        public JSONStorage(string fileName)
        {
            this.fileName = fileName;
            this.ser = new DataContractJsonSerializer(typeof(Logic.Analyzer));
        }

        /// <summary>
        /// Sauve l'objet métier
        /// </summary>
        /// <param name="analyzer">l'objet métier</param>
        public void Save(Logic.Analyzer analyzer)
        {
            using(FileStream file = new FileStream(fileName,FileMode.Create))
            {
                ser.WriteObject(file, analyzer);
            }
        }

        /// <summary>
        /// Charge ou créée (si aucun fichier) les données métier
        /// </summary>
        /// <returns>l'objet métier créé</returns>
        public Logic.Analyzer Load()
        {
            Logic.Analyzer analyzer;
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    analyzer = ser.ReadObject(file) as Logic.Analyzer;
                }
            }
            catch
            {
                analyzer = new Logic.Analyzer();
            }
            return analyzer;
        }

    }
}
