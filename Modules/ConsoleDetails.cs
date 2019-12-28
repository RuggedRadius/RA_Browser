using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Modules
{
    public static class ConsoleInformation
    {
        public struct ConsoleNames
        {
            public const string MegaDrive = "Mega Drive";
            public const string Nintendo64 = "Nintendo 64";
            public const string SNES = "SNES";
            public const string GameBoy = "GameBoy";
            public const string GameBoyAdvance = "GameBoy Advance";
            public const string GameBoyColor = "GameBoy Color";
            public const string NES = "NES";
            //public const string PCEngine;
            //public const string SegaCD;
            //public const string _32X;
            public const string MasterSystem = "Master System";
            //public const string PlayStation;
            //public const string AtariLynx;
            //public const string NeoGeoPocket;
            //public const string GameGear;
            //public const string GameCube;
            //public const string AtariJaguar;
            //public const string NintendoDS;
            //public const string Wii;
            //public const string WiiU;
            //public const string PlayStation2;
            //public const string Xbox;
            //public const string PokemonMini;
            //public const string Atari2600;
            //public const string DOS;
            //public const string Arcade;
            //public const string VirtualBoy;
            //public const string MSX;
            //public const string Commodore64;
            //public const string ZX81;
            //public const string Oric;
            //public const string SG_1000;
            //public const string VIC_20;
            //public const string Amiga;
            //public const string AtariST;
            //public const string AmstradCPC;
            //public const string AppleII;
            //public const string Saturn;
            //public const string Dreamcast;
            //public const string PlayStationPortable;
            //public const string PhilipsCD_i;
            //public const string _3DOInteractiveMultiplayer;
            //public const string ColecoVision;
            //public const string Intellivision;
            //public const string Vectrex;
            //public const string PC8000_8800;
            //public const string PC9800;
            //public const string PC_FX;
            //public const string Atari5200;
            //public const string Atari7800;
            //public const string X68K;
            //public const string WonderSwan;
            //public const string CassetteVision;
            //public const string SuperCassetteVision;
        }

        public struct ConsoleImages
        {
            public static Image MegaDrive = Properties.Resources.megaDrive;
            public static Image Nintendo64 = Properties.Resources.n64;
            public static Image SNES = Properties.Resources.snes;
            public static Image GameBoy = Properties.Resources.gb;
            public static Image GameBoyAdvance = Properties.Resources.gba;
            public static Image GameBoyColor = Properties.Resources.gbc;
            public static Image NES = Properties.Resources.nes;
            public static Image PCEngine = Properties.Resources.PC_Engine;
            public static Image SegaCD = Properties.Resources.sega_cd;
            public static Image _32X = Properties.Resources.sega_32x;
            public static Image MasterSystem = Properties.Resources.sms;
            public static Image PlayStation = Properties.Resources.ps1;
            public static Image AtariLynx = Properties.Resources.atari_lynx;
            public static Image NeoGeoPocket = Properties.Resources.neo_geo;
            public static Image GameGear = Properties.Resources.game_gear;
            public static Image GameCube = Properties.Resources.gamecube;
            public static Image AtariJaguar = Properties.Resources.atari_jaguar;
            public static Image NintendoDS = Properties.Resources.nintendo_ds;
            public static Image Wii = Properties.Resources.wii;
            public static Image WiiU = Properties.Resources.wii_u;
            public static Image PlayStation2 = Properties.Resources.ps2;
            public static Image Xbox = Properties.Resources.xbox;
            public static Image PokemonMini = Properties.Resources.pokemon_mini;
            public static Image Atari2600 = Properties.Resources.atari_2600;
            public static Image DOS = Properties.Resources.dos;
            public static Image Arcade = Properties.Resources.arcade;
            public static Image VirtualBoy = Properties.Resources.cirtual_boy;
            public static Image MSX = Properties.Resources.msx;
            public static Image Commodore64 = Properties.Resources.c64;
            public static Image ZX81 = Properties.Resources.zx81;
            public static Image Oric = Properties.Resources.oric;
            public static Image SG_1000 = Properties.Resources.sg_1000;
            public static Image VIC_20 = Properties.Resources.vic_20;
            public static Image Amiga = Properties.Resources.amiga;
            public static Image AtariST = Properties.Resources.atari_st;
            public static Image AmstradCPC = Properties.Resources.amstrad_cpc;
            public static Image AppleII = Properties.Resources.apple_ii;
            public static Image Saturn = Properties.Resources.sega_saturn;
            public static Image Dreamcast = Properties.Resources.dreamcast;
            public static Image PlayStationPortable = Properties.Resources.psp;
            public static Image PhilipsCD_i = Properties.Resources.philips_cd_i;
            public static Image _3DOInteractiveMultiplayer = Properties.Resources._3do_interactive;
            public static Image ColecoVision = Properties.Resources.colecovision;
            public static Image Intellivision = Properties.Resources.intellivision;
            public static Image Vectrex = Properties.Resources.vectrex;
            public static Image PC8000_8800 = Properties.Resources.pc_8000;
            public static Image PC9800 = Properties.Resources.pc_9800;
            public static Image PC_FX = Properties.Resources.pc_fx;
            public static Image Atari5200 = Properties.Resources.atari_5200;
            public static Image Atari7800 = Properties.Resources.atari_7800;
            public static Image X68K = Properties.Resources.x68k;
            public static Image WonderSwan = Properties.Resources.wonderswan;
            public static Image CassetteVision = Properties.Resources.Cassette_Vision;
            public static Image SuperCassetteVision = Properties.Resources.super_Cassette_Vision;
        }
    }
}
