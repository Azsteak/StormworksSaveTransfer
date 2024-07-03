using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Stormworks_Save_Transfer {
    public class SaveData {

        #region XML_Elements
        private XDocument docData;
        private XElement GameDataElement;
        private XElement DifficultySettingsElement;
        private XElement GameModeSettingsElement;
        private XElement ActivePlaylistElement;
        private XElement UnlockedCompsElement;
        private XElement UnlockedResrchElement;

        private XElement TilesElement;
        private XElement DiscoveredTilesElement;
        private XElement PurchasedTilesElement;
        #endregion

        public string Seed { get; set; }

        #region Displayed_Properties
        public List<SaveProperty> GameData { get; set; }
        public List<SaveProperty> DifficultySettings { get; set; }
        public List<SaveProperty> GameModeSettings { get; set; }
        #endregion

        #region Hidden_Progression_Data
        private List<ValueTag> activePlaylist;
        private List<ValueTag> unlockedComps;
        private List<ValueTag> unlockedResrch;

        private List<TileTag> discoveredTiles;
        private List<TileTag> purchasedTiles;
        #endregion

        public SaveData(XDocument doc) {
            docData = doc;

            GameDataElement = (from elements in docData.Root.Elements() where elements.Name == "game_data" select elements).First();
            DifficultySettingsElement = (from elements in GameDataElement.Elements() where elements.Name == "difficulty_settings" select elements).First();
            GameModeSettingsElement = (from elements in GameDataElement.Elements() where elements.Name == "game_mode_settings" select elements).First();

            ActivePlaylistElement = (from elements in GameDataElement.Elements() where elements.Name == "active_playlists" select elements).First();
            UnlockedCompsElement = (from elements in GameDataElement.Elements() where elements.Name == "unlocked_components" select elements).First();
            UnlockedResrchElement = (from elements in GameDataElement.Elements() where elements.Name == "unlocked_research" select elements).First();

            TilesElement = (from elements in docData.Root.Elements() where elements.Name == "tiles" select elements).First();
            Seed = TilesElement.Attributes().First().Value;
            DiscoveredTilesElement = (from elements in TilesElement.Elements() where elements.Name == "discovered_tiles" select elements).First();
            PurchasedTilesElement = (from elements in TilesElement.Elements() where elements.Name == "purchased_tiles" select elements).First();

            UpdateDataFromXDocument();
        }

        public void CopyDataFrom(SaveData sourceSave, bool copyGameData, bool copyDifficulty, bool copyGameMode) {
            if (copyGameData) SetTagParameters(GameDataElement, sourceSave.GameData);
            if (copyDifficulty) SetTagParameters(DifficultySettingsElement, sourceSave.DifficultySettings);
            if (copyGameMode) SetTagParameters(GameModeSettingsElement, sourceSave.GameModeSettings);

            SetTagChildren(ActivePlaylistElement, sourceSave.activePlaylist);
            SetTagChildren(UnlockedCompsElement, sourceSave.unlockedComps);
            SetTagChildren(UnlockedResrchElement, sourceSave.unlockedResrch, "r");

            SetTileData(DiscoveredTilesElement, sourceSave.discoveredTiles);
            SetTileData(PurchasedTilesElement, sourceSave.purchasedTiles);

            UpdateDataFromXDocument();
        }

        private void UpdateDataFromXDocument() {
            GameData = GetTagParameters(GameDataElement);
            DifficultySettings = GetTagParameters(DifficultySettingsElement);
            GameModeSettings = GetTagParameters(GameModeSettingsElement);

            activePlaylist = GetTagChildren(ActivePlaylistElement);
            unlockedComps = GetTagChildren(UnlockedCompsElement);
            unlockedResrch = GetTagChildren(UnlockedResrchElement);

            discoveredTiles = GetTileData(DiscoveredTilesElement);
            purchasedTiles = GetTileData(PurchasedTilesElement);
        }

        private List<SaveProperty> GetTagParameters(XElement tag) {
            XAttribute[] attributes = tag.Attributes().ToArray();
            List<SaveProperty> properties = new List<SaveProperty>();

            for (int i = 0; i < attributes.Length; i++) {
                XAttribute attr = attributes[i];

                if (attr.Value == "true" || attr.Value == "false") {
                    attr.Value = $"{attr.Value[0].ToString().ToUpper()}{attr.Value.Substring(1)}";
                }

                properties.Add(new SaveProperty() {
                    XKey = attr.Name,
                    Key = attr.Name.LocalName,
                    Value = attr.Value,
                });
            }

            return properties;
        }

        private void SetTagParameters(XElement tag, List<SaveProperty> data) {
            foreach (SaveProperty property in data) {
                string value = property.Value;

                tag.SetAttributeValue(property.Key, value);
            }
        }

        private List<ValueTag> GetTagChildren(XElement tag) {
            List<ValueTag> children = new List<ValueTag>();
            
            foreach (XElement child in tag.Elements()) {
                XAttribute attribute = child.Attributes().Where(attr => attr.Name == "value").First();
                children.Add(new ValueTag() { 
                    tag = child,
                    attributeName = attribute.Name,
                    Name = child.Name.LocalName,
                    Value = attribute.Value,
                });
            }

            return children;
        }

        private void SetTagChildren(XElement tag, List<ValueTag> data, string childrenName = "") {
            tag.RemoveAll();

            XName childName;

            if (string.IsNullOrEmpty(childrenName))
                childName = tag.Name;
            else {
                childName = XName.Get(childrenName);
            }


            foreach (ValueTag property in data) {
                XElement newElement = new XElement(childName);
                newElement.SetAttributeValue(property.attributeName, property.Value);
                tag.Add(newElement);
            }
        }


        private List<TileTag> GetTileData(XElement tileTag) {
            List<TileTag> tileTags = new List<TileTag>();

            foreach (XElement child in tileTag.Elements()) {
                if (child.Elements().Count() == 0)
                    continue;

                XElement dataElement = child.Elements().First();
                if (dataElement.Attributes().Count() > 0) {
                    tileTags.Add(new TileTag() {
                        X = dataElement.Attributes().Where(attr => attr.Name == "x").Count() == 0 ? null : dataElement.Attributes().Where(attr => attr.Name == "x").First().Value,
                        Y = dataElement.Attributes().Where(attr => attr.Name == "y").Count() == 0 ? null : dataElement.Attributes().Where(attr => attr.Name == "y").First().Value,
                    });
                }
            }

            return tileTags;
        }

        private void SetTileData(XElement tag, List<TileTag> data) {
            tag.RemoveAll();

            foreach (TileTag tileTag in data) {
                XElement newTag = new XElement("tile");
                XElement dataTag = new XElement("value");

                dataTag.SetAttributeValue("x", tileTag.X);
                dataTag.SetAttributeValue("y", tileTag.Y);

                newTag.Add(dataTag);
                tag.Add(newTag);
            }
        }

        public override string ToString() {
            return docData.ToString();
        }
    }


    public class SaveProperty {
        public XName XKey;
        public string Key {  get; set; }
        public string Value { get; set; }
    }

    public class ValueTag {
        public XElement tag;
        public XName attributeName;
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class TileTag {
        public string X;
        public string Y;
    }
}
