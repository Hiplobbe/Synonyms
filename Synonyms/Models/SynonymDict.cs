using System.Linq;

namespace Synonyms.Models
{
    public class SynonymDict
    {
        private Dictionary<string, List<string>> _Synonyms = new Dictionary<string, List<string>>();

        /// <summary>
        /// Adds a single synonym to the word.
        /// </summary>
        public void Add(string word, string synonym)
        {
            //To make the code a bit more readable and to only check once.
            bool wordExist = _Synonyms.ContainsKey(word);
            bool synExist = _Synonyms.ContainsKey(synonym);

            if(!wordExist)
            {
                _Synonyms.Add(word, new List<string> { synonym });
            }
            if (!synExist)
            {
                _Synonyms.Add(synonym, new List<string> { word });
            }

            if (!_Synonyms[word].Any(w => w == synonym)) // If word already isn't connected to the synonym already.
            {
                _Synonyms[word].Add(synonym);
            }
            
            if (!_Synonyms[synonym].Any(w => w == word)) // If synonym already isn't connected to the word already.
            {
                _Synonyms[synonym].Add(word);
            }

            //Sync the lists and its children synonyms.
            Add(
                word,
                _Synonyms[synonym].Where(w => w != word && !_Synonyms[word].Contains(w)).ToList()
            );

            Add(
                synonym,
                _Synonyms[word].Where(w => w != synonym && !_Synonyms[synonym].Contains(w)).ToList()
            );
        }        

        /// <summary>
        /// Adds a list of synonyms to the word.
        /// </summary>
        public void Add(string word, List<string> synonyms)
        {
            foreach(string synonym in synonyms) 
            { 
                Add(word, synonym); 
            }
        }

        public List<string> GetSynonyms(string word) 
        {
            if (_Synonyms.ContainsKey(word))
            {
                return _Synonyms[word];
            }

            return null;
        }
    }
}
