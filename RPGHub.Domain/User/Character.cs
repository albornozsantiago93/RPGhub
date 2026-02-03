using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class Character
    {
        public Character()
        {
            
        }
        public Character(string name, string picture, Class classAux, Race race)
        {
            Name  = name;
            Picture = picture;
            Class = classAux;
            Race = race;
        }
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }
        public Class Class { get; set; }
        public Race Race { get; set; }
        public int Level { get; set; } = 1;
        public string? Picture { get; set; }

        // JSON
        [Column(TypeName = "Varchar(256)")]
        public string? Stats { get; set; }
        [Column(TypeName = "Varchar(512)")]
        public string? Inventory { get; set; }
        [Column(TypeName = "Varchar(512)")]

        public string? Description { get; set; }
        // FK
        public Guid OwnerId { get; set; }
        public virtual SystemUser Owner { get; set; }
        public Guid? GameSessionId { get; set; }
        public virtual GameSession Session { get; set; }
    }

}

    #region  Enums
    public enum Class
    {
        Barbarian = 1,      // Bárbaro
        Bard = 2,           // Bardo
        Cleric = 3,         // Clérigo
        Druid = 4,          // Druida
        Fighter = 5,        // Guerrero
        Monk = 6,           // Monje
        Paladin = 7,        // Paladín
        Ranger = 8,         // Explorador
        Rogue = 9,          // Pícaro
        Sorcerer = 10,      // Hechicero
        Warlock = 11,       // Brujo
        Wizard = 12,        // Mago
        Artificer = 13      // Artífice
    }

    public enum Race
    {
        // Player's Handbook
        Human = 1,
        Dwarf = 2,
        Elf = 3,
        Halfling = 4,
        Dragonborn = 5,
        Gnome = 6,
        HalfElf = 7,
        HalfOrc = 8,
        Tiefling = 9,

        // Mordenkainen / Volo (actualizados a Monsters of the Multiverse)
        Aasimar = 10,
        Goliath = 11,
        Genasi = 12,
        Goblin = 13,
        Bugbear = 14,
        Hobgoblin = 15,
        Kobold = 16,
        Lizardfolk = 17,
        Orc = 18,
        Tabaxi = 19,
        Triton = 20,
        Firbolg = 21,
        Kenku = 22,
        YuanTi = 23,
        Tortle = 24,
        Minotaur = 25,
        Centaur = 26,
        Satyr = 27,
        Leonin = 28,
        Loxodon = 29,
        Vedalken = 30,

        // Eberron
        Warforged = 31,
        Changeling = 32,
        Kalashtar = 33,
        Shifter = 34,

        // Ravnica
        SimicHybrid = 35,
        VedalkenRavni
    }
    #endregion
