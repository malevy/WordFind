using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace WordFind.Sources.WordList
{
    public class EmbeddedWordListSource : IWordListSource
    {
        private List<string> _words;

        public void Load()
        {
            _words = new List<string>();
            var provider = new EmbeddedFileProvider(this.GetType().Assembly);
            using (var stream = provider.GetFileInfo("Resources/words_alpha.txt").CreateReadStream())
            using (var reader = new StreamReader(stream))
            {
                string word;
                while ((word = reader.ReadLine()) != null)
                {
                    _words.Add(word);
                }
            }
        }

        public IEnumerable<string> Words()
        {
            if (null == _words) this.Load();

            return _words;
        }
    }
}