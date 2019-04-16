﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponent.IO;
using Kontract.Attributes;
using Kontract.Interfaces.Common;
using Kontract.Interfaces.Text;

namespace plugin_yuusha_shisu.MSG
{
    [Export(typeof(MSGAdapter))]
    [Export(typeof(IPlugin))]
    [PluginInfo("plugin_yuusha_shisu_MSG", "Death of a Hero", "MSG", "StorMyu")]
    [PluginExtensionInfo("*.bin")]
    public sealed class MSGAdapter : ITextAdapter, IIdentifyFiles, ILoadFiles, ISaveFiles
    {
        private MSG _format;

        #region Properties

        public IEnumerable<TextEntry> Entries => _format?.Entries;

        public string NameFilter => @".*";

        public int NameMaxLength => 0;

        public string LineEndings { get; set; } = "\n";

        public bool LeaveOpen { get; set; }

        #endregion

        public bool Identify(StreamInfo input)
        {
            try
            {
                using (var br = new BinaryReaderX(input.FileData, true))
                {
                    var magic = br.ReadString(4);
                    var fileSize = br.ReadInt32();
                    return magic == "TEXT" && fileSize == br.BaseStream.Length;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Load(StreamInfo input)
        {
            _format = new MSG(input.FileData);
        }

        public void Save(StreamInfo output, int versionIndex = 0)
        {
            _format.Save(output.FileData);
        }

        public void Dispose() { }


    }
}
