using System;
using Ascend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ascend.DataAccess
{
    public class AscendContext : DbContext
    {
        public AscendContext(DbContextOptions<AscendContext> options) : base(options) { }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Uom> Uom { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<DesignationPermission> DesignationPermission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.email).IsUnique();
            });

            modelBuilder.Entity<Country>().HasData(
                new Country() { countryId = 1, countryCode = "AFG", countryName = "Afghanistan", callingCode = "93" },
                new Country() { countryId = 2, countryCode = "ALB", countryName = "Albania", callingCode = "355" },
                new Country() { countryId = 3, countryCode = "DZA", countryName = "Algeria", callingCode = "213" },
                new Country() { countryId = 4, countryCode = "ASM", countryName = "AmericanSamoa", callingCode = "1-684" },
                new Country() { countryId = 5, countryCode = "AND", countryName = "Andorra", callingCode = "376" },
                new Country() { countryId = 6, countryCode = "AGO", countryName = "Angola", callingCode = "244" },
                new Country() { countryId = 7, countryCode = "AIA", countryName = "Anguilla", callingCode = "1-264" },
                new Country() { countryId = 8, countryCode = "ATA", countryName = "Antarctica", callingCode = "672" },
                new Country() { countryId = 9, countryCode = "ATG", countryName = "AntiguaandBarbuda", callingCode = "1-268" },
                new Country() { countryId = 10, countryCode = "ARG", countryName = "Argentina", callingCode = "54" },
                new Country() { countryId = 11, countryCode = "ARM", countryName = "Armenia", callingCode = "374" },
                new Country() { countryId = 12, countryCode = "ABW", countryName = "Aruba", callingCode = "297" },
                new Country() { countryId = 13, countryCode = "AUS", countryName = "Australia", callingCode = "61" },
                new Country() { countryId = 14, countryCode = "AUT", countryName = "Austria", callingCode = "43" },
                new Country() { countryId = 15, countryCode = "AZE", countryName = "Azerbaijan", callingCode = "994" },
                new Country() { countryId = 16, countryCode = "BHS", countryName = "Bahamas", callingCode = "1-242" },
                new Country() { countryId = 17, countryCode = "BHR", countryName = "Bahrain", callingCode = "973" },
                new Country() { countryId = 18, countryCode = "BGD", countryName = "Bangladesh", callingCode = "880" },
                new Country() { countryId = 19, countryCode = "BRB", countryName = "Barbados", callingCode = "1-246" },
                new Country() { countryId = 20, countryCode = "BLR", countryName = "Belarus", callingCode = "375" },
                new Country() { countryId = 21, countryCode = "BEL", countryName = "Belgium", callingCode = "32" },
                new Country() { countryId = 22, countryCode = "BLZ", countryName = "Belize", callingCode = "501" },
                new Country() { countryId = 23, countryCode = "BEN", countryName = "Benin", callingCode = "229" },
                new Country() { countryId = 24, countryCode = "BMU", countryName = "Bermuda", callingCode = "1-441" },
                new Country() { countryId = 25, countryCode = "BTN", countryName = "Bhutan", callingCode = "975" },
                new Country() { countryId = 26, countryCode = "BOL", countryName = "Bolivia", callingCode = "591" },
                new Country() { countryId = 27, countryCode = "BIH", countryName = "BosniaandHerzegovina", callingCode = "387" },
                new Country() { countryId = 28, countryCode = "BWA", countryName = "Botswana", callingCode = "267" },
                new Country() { countryId = 29, countryCode = "BRA", countryName = "Brazil", callingCode = "55" },
                new Country() { countryId = 30, countryCode = "IOT", countryName = "BritishIndianOceanTerritory", callingCode = "246" },
                new Country() { countryId = 31, countryCode = "VGB", countryName = "BritishVirginIslands", callingCode = "1-284" },
                new Country() { countryId = 32, countryCode = "BRN", countryName = "Brunei", callingCode = "673" },
                new Country() { countryId = 33, countryCode = "BGR", countryName = "Bulgaria", callingCode = "359" },
                new Country() { countryId = 34, countryCode = "BFA", countryName = "BurkinaFaso", callingCode = "226" },
                new Country() { countryId = 35, countryCode = "BDI", countryName = "Burundi", callingCode = "257" },
                new Country() { countryId = 36, countryCode = "KHM", countryName = "Cambodia", callingCode = "855" },
                new Country() { countryId = 37, countryCode = "CMR", countryName = "Cameroon", callingCode = "237" },
                new Country() { countryId = 38, countryCode = "CAN", countryName = "Canada", callingCode = "1" },
                new Country() { countryId = 39, countryCode = "CPV", countryName = "CapeVerde", callingCode = "238" },
                new Country() { countryId = 40, countryCode = "CYM", countryName = "CaymanIslands", callingCode = "1-345" },
                new Country() { countryId = 41, countryCode = "CAF", countryName = "CentralAfricanRepublic", callingCode = "236" },
                new Country() { countryId = 42, countryCode = "TCD", countryName = "Chad", callingCode = "235" },
                new Country() { countryId = 43, countryCode = "CHL", countryName = "Chile", callingCode = "56" },
                new Country() { countryId = 44, countryCode = "CHN", countryName = "China", callingCode = "86" },
                new Country() { countryId = 45, countryCode = "CXR", countryName = "ChristmasIsland", callingCode = "61" },
                new Country() { countryId = 46, countryCode = "CCK", countryName = "CocosIslands", callingCode = "61" },
                new Country() { countryId = 47, countryCode = "COL", countryName = "Colombia", callingCode = "57" },
                new Country() { countryId = 48, countryCode = "COM", countryName = "Comoros", callingCode = "269" },
                new Country() { countryId = 49, countryCode = "COK", countryName = "CookIslands", callingCode = "682" },
                new Country() { countryId = 50, countryCode = "CRI", countryName = "CostaRica", callingCode = "506" },
                new Country() { countryId = 51, countryCode = "HRV", countryName = "Croatia", callingCode = "385" },
                new Country() { countryId = 52, countryCode = "CUB", countryName = "Cuba", callingCode = "53" },
                new Country() { countryId = 53, countryCode = "CUW", countryName = "Curacao", callingCode = "599" },
                new Country() { countryId = 54, countryCode = "CYP", countryName = "Cyprus", callingCode = "357" },
                new Country() { countryId = 55, countryCode = "CZE", countryName = "CzechRepublic", callingCode = "420" },
                new Country() { countryId = 56, countryCode = "COD", countryName = "DemocraticRepublicoftheCongo", callingCode = "243" },
                new Country() { countryId = 57, countryCode = "DNK", countryName = "Denmark", callingCode = "45" },
                new Country() { countryId = 58, countryCode = "DJI", countryName = "Djibouti", callingCode = "253" },
                new Country() { countryId = 59, countryCode = "DMA", countryName = "Dominica", callingCode = "1-767" },
                new Country() { countryId = 60, countryCode = "DOM", countryName = "DominicanRepublic", callingCode = "1-809" },
                new Country() { countryId = 61, countryCode = "TLS", countryName = "EastTimor", callingCode = "670" },
                new Country() { countryId = 62, countryCode = "ECU", countryName = "Ecuador", callingCode = "593" },
                new Country() { countryId = 63, countryCode = "EGY", countryName = "Egypt", callingCode = "20" },
                new Country() { countryId = 64, countryCode = "SLV", countryName = "ElSalvador", callingCode = "503" },
                new Country() { countryId = 65, countryCode = "GNQ", countryName = "EquatorialGuinea", callingCode = "240" },
                new Country() { countryId = 66, countryCode = "ERI", countryName = "Eritrea", callingCode = "291" },
                new Country() { countryId = 67, countryCode = "EST", countryName = "Estonia", callingCode = "372" },
                new Country() { countryId = 68, countryCode = "ETH", countryName = "Ethiopia", callingCode = "251" },
                new Country() { countryId = 69, countryCode = "FLK", countryName = "FalklandIslands", callingCode = "500" },
                new Country() { countryId = 70, countryCode = "FRO", countryName = "FaroeIslands", callingCode = "298" },
                new Country() { countryId = 71, countryCode = "FJI", countryName = "Fiji", callingCode = "679" },
                new Country() { countryId = 72, countryCode = "FIN", countryName = "Finland", callingCode = "358" },
                new Country() { countryId = 73, countryCode = "FRA", countryName = "France", callingCode = "33" },
                new Country() { countryId = 74, countryCode = "PYF", countryName = "FrenchPolynesia", callingCode = "689" },
                new Country() { countryId = 75, countryCode = "GAB", countryName = "Gabon", callingCode = "241" },
                new Country() { countryId = 76, countryCode = "GMB", countryName = "Gambia", callingCode = "220" },
                new Country() { countryId = 77, countryCode = "GEO", countryName = "Georgia", callingCode = "995" },
                new Country() { countryId = 78, countryCode = "DEU", countryName = "Germany", callingCode = "49" },
                new Country() { countryId = 79, countryCode = "GHA", countryName = "Ghana", callingCode = "233" },
                new Country() { countryId = 80, countryCode = "GIB", countryName = "Gibraltar", callingCode = "350" },
                new Country() { countryId = 81, countryCode = "GRC", countryName = "Greece", callingCode = "30" },
                new Country() { countryId = 82, countryCode = "GRL", countryName = "Greenland", callingCode = "299" },
                new Country() { countryId = 83, countryCode = "GRD", countryName = "Grenada", callingCode = "1-473" },
                new Country() { countryId = 84, countryCode = "GUM", countryName = "Guam", callingCode = "1-671" },
                new Country() { countryId = 85, countryCode = "GTM", countryName = "Guatemala", callingCode = "502" },
                new Country() { countryId = 86, countryCode = "GGY", countryName = "Guernsey", callingCode = "1481" },
                new Country() { countryId = 87, countryCode = "GIN", countryName = "Guinea", callingCode = "224" },
                new Country() { countryId = 88, countryCode = "GNB", countryName = "Guinea-Bissau", callingCode = "245" },
                new Country() { countryId = 89, countryCode = "GUY", countryName = "Guyana", callingCode = "592" },
                new Country() { countryId = 90, countryCode = "HTI", countryName = "Haiti", callingCode = "509" },
                new Country() { countryId = 91, countryCode = "HND", countryName = "Honduras", callingCode = "504" },
                new Country() { countryId = 92, countryCode = "HKG", countryName = "HongKong", callingCode = "852" },
                new Country() { countryId = 93, countryCode = "HUN", countryName = "Hungary", callingCode = "36" },
                new Country() { countryId = 94, countryCode = "ISL", countryName = "Iceland", callingCode = "354" },
                new Country() { countryId = 95, countryCode = "IND", countryName = "India", callingCode = "91" },
                new Country() { countryId = 96, countryCode = "IDN", countryName = "Indonesia", callingCode = "62" },
                new Country() { countryId = 97, countryCode = "IRN", countryName = "Iran", callingCode = "98" },
                new Country() { countryId = 98, countryCode = "IRQ", countryName = "Iraq", callingCode = "964" },
                new Country() { countryId = 99, countryCode = "IRL", countryName = "Ireland", callingCode = "353" },
                new Country() { countryId = 100, countryCode = "IMN", countryName = "IsleofMan", callingCode = "1624" },
                new Country() { countryId = 101, countryCode = "ISR", countryName = "Israel", callingCode = "972" },
                new Country() { countryId = 102, countryCode = "ITA", countryName = "Italy", callingCode = "39" },
                new Country() { countryId = 103, countryCode = "CIV", countryName = "IvoryCoast", callingCode = "225" },
                new Country() { countryId = 104, countryCode = "JAM", countryName = "Jamaica", callingCode = "1-876" },
                new Country() { countryId = 105, countryCode = "JPN", countryName = "Japan", callingCode = "81" },
                new Country() { countryId = 106, countryCode = "JEY", countryName = "Jersey", callingCode = "1534" },
                new Country() { countryId = 107, countryCode = "JOR", countryName = "Jordan", callingCode = "962" },
                new Country() { countryId = 108, countryCode = "KAZ", countryName = "Kazakhstan", callingCode = "7" },
                new Country() { countryId = 109, countryCode = "KEN", countryName = "Kenya", callingCode = "254" },
                new Country() { countryId = 110, countryCode = "KIR", countryName = "Kiribati", callingCode = "686" },
                new Country() { countryId = 111, countryCode = "XKX", countryName = "Kosovo", callingCode = "383" },
                new Country() { countryId = 112, countryCode = "KWT", countryName = "Kuwait", callingCode = "965" },
                new Country() { countryId = 113, countryCode = "KGZ", countryName = "Kyrgyzstan", callingCode = "996" },
                new Country() { countryId = 114, countryCode = "LAO", countryName = "Laos", callingCode = "856" },
                new Country() { countryId = 115, countryCode = "LVA", countryName = "Latvia", callingCode = "371" },
                new Country() { countryId = 116, countryCode = "LBN", countryName = "Lebanon", callingCode = "961" },
                new Country() { countryId = 117, countryCode = "LSO", countryName = "Lesotho", callingCode = "266" },
                new Country() { countryId = 118, countryCode = "LBR", countryName = "Liberia", callingCode = "231" },
                new Country() { countryId = 119, countryCode = "LBY", countryName = "Libya", callingCode = "218" },
                new Country() { countryId = 120, countryCode = "LIE", countryName = "Liechtenstein", callingCode = "423" },
                new Country() { countryId = 121, countryCode = "LTU", countryName = "Lithuania", callingCode = "370" },
                new Country() { countryId = 122, countryCode = "LUX", countryName = "Luxembourg", callingCode = "352" },
                new Country() { countryId = 123, countryCode = "MAC", countryName = "Macao", callingCode = "853" },
                new Country() { countryId = 124, countryCode = "MKD", countryName = "Macedonia", callingCode = "389" },
                new Country() { countryId = 125, countryCode = "MDG", countryName = "Madagascar", callingCode = "261" },
                new Country() { countryId = 126, countryCode = "MWI", countryName = "Malawi", callingCode = "265" },
                new Country() { countryId = 127, countryCode = "MYS", countryName = "Malaysia", callingCode = "60" },
                new Country() { countryId = 128, countryCode = "MDV", countryName = "Maldives", callingCode = "960" },
                new Country() { countryId = 129, countryCode = "MLI", countryName = "Mali", callingCode = "223" },
                new Country() { countryId = 130, countryCode = "MLT", countryName = "Malta", callingCode = "356" },
                new Country() { countryId = 131, countryCode = "MHL", countryName = "MarshallIslands", callingCode = "692" },
                new Country() { countryId = 132, countryCode = "MRT", countryName = "Mauritania", callingCode = "222" },
                new Country() { countryId = 133, countryCode = "MUS", countryName = "Mauritius", callingCode = "230" },
                new Country() { countryId = 134, countryCode = "MYT", countryName = "Mayotte", callingCode = "262" },
                new Country() { countryId = 135, countryCode = "MEX", countryName = "Mexico", callingCode = "52" },
                new Country() { countryId = 136, countryCode = "FSM", countryName = "Micronesia", callingCode = "691" },
                new Country() { countryId = 137, countryCode = "MDA", countryName = "Moldova", callingCode = "373" },
                new Country() { countryId = 138, countryCode = "MCO", countryName = "Monaco", callingCode = "377" },
                new Country() { countryId = 139, countryCode = "MNG", countryName = "Mongolia", callingCode = "976" },
                new Country() { countryId = 140, countryCode = "MNE", countryName = "Montenegro", callingCode = "382" },
                new Country() { countryId = 141, countryCode = "MSR", countryName = "Montserrat", callingCode = "1-664" },
                new Country() { countryId = 142, countryCode = "MAR", countryName = "Morocco", callingCode = "212" },
                new Country() { countryId = 143, countryCode = "MOZ", countryName = "Mozambique", callingCode = "258" },
                new Country() { countryId = 144, countryCode = "MMR", countryName = "Myanmar", callingCode = "95" },
                new Country() { countryId = 145, countryCode = "NAM", countryName = "Namibia", callingCode = "264" },
                new Country() { countryId = 146, countryCode = "NRU", countryName = "Nauru", callingCode = "674" },
                new Country() { countryId = 147, countryCode = "NPL", countryName = "Nepal", callingCode = "977" },
                new Country() { countryId = 148, countryCode = "NLD", countryName = "Netherlands", callingCode = "31" },
                new Country() { countryId = 149, countryCode = "ANT", countryName = "NetherlandsAntilles", callingCode = "599" },
                new Country() { countryId = 150, countryCode = "NCL", countryName = "NewCaledonia", callingCode = "687" },
                new Country() { countryId = 151, countryCode = "NZL", countryName = "NewZealand", callingCode = "64" },
                new Country() { countryId = 152, countryCode = "NIC", countryName = "Nicaragua", callingCode = "505" },
                new Country() { countryId = 153, countryCode = "NER", countryName = "Niger", callingCode = "227" },
                new Country() { countryId = 154, countryCode = "NGA", countryName = "Nigeria", callingCode = "234" },
                new Country() { countryId = 155, countryCode = "NIU", countryName = "Niue", callingCode = "683" },
                new Country() { countryId = 156, countryCode = "PRK", countryName = "NorthKorea", callingCode = "850" },
                new Country() { countryId = 157, countryCode = "MNP", countryName = "NorthernMarianaIslands", callingCode = "1-670" },
                new Country() { countryId = 158, countryCode = "NOR", countryName = "Norway", callingCode = "47" },
                new Country() { countryId = 159, countryCode = "OMN", countryName = "Oman", callingCode = "968" },
                new Country() { countryId = 160, countryCode = "PAK", countryName = "Pakistan", callingCode = "92" },
                new Country() { countryId = 161, countryCode = "PLW", countryName = "Palau", callingCode = "680" },
                new Country() { countryId = 162, countryCode = "PSE", countryName = "Palestine", callingCode = "970" },
                new Country() { countryId = 163, countryCode = "PAN", countryName = "Panama", callingCode = "507" },
                new Country() { countryId = 164, countryCode = "PNG", countryName = "PapuaNewGuinea", callingCode = "675" },
                new Country() { countryId = 165, countryCode = "PRY", countryName = "Paraguay", callingCode = "595" },
                new Country() { countryId = 166, countryCode = "PER", countryName = "Peru", callingCode = "51" },
                new Country() { countryId = 167, countryCode = "PHL", countryName = "Philippines", callingCode = "63" },
                new Country() { countryId = 168, countryCode = "PCN", countryName = "Pitcairn", callingCode = "64" },
                new Country() { countryId = 169, countryCode = "POL", countryName = "Poland", callingCode = "48" },
                new Country() { countryId = 170, countryCode = "PRT", countryName = "Portugal", callingCode = "351" },
                new Country() { countryId = 171, countryCode = "PRI", countryName = "PuertoRico", callingCode = "1-787" },
                new Country() { countryId = 172, countryCode = "QAT", countryName = "Qatar", callingCode = "974" },
                new Country() { countryId = 173, countryCode = "COG", countryName = "RepublicoftheCongo", callingCode = "242" },
                new Country() { countryId = 174, countryCode = "REU", countryName = "Reunion", callingCode = "262" },
                new Country() { countryId = 175, countryCode = "ROU", countryName = "Romania", callingCode = "40" },
                new Country() { countryId = 176, countryCode = "RUS", countryName = "Russia", callingCode = "7" },
                new Country() { countryId = 177, countryCode = "RWA", countryName = "Rwanda", callingCode = "250" },
                new Country() { countryId = 178, countryCode = "BLM", countryName = "SaintBarthelemy", callingCode = "590" },
                new Country() { countryId = 179, countryCode = "SHN", countryName = "SaintHelena", callingCode = "290" },
                new Country() { countryId = 180, countryCode = "KNA", countryName = "SaintKittsandNevis", callingCode = "1-869" },
                new Country() { countryId = 181, countryCode = "LCA", countryName = "SaintLucia", callingCode = "1-758" },
                new Country() { countryId = 182, countryCode = "MAF", countryName = "SaintMartin", callingCode = "590" },
                new Country() { countryId = 183, countryCode = "SPM", countryName = "SaintPierreandMiquelon", callingCode = "508" },
                new Country() { countryId = 184, countryCode = "VCT", countryName = "SaintVincentandtheGrenadines", callingCode = "1-784" },
                new Country() { countryId = 185, countryCode = "WSM", countryName = "Samoa", callingCode = "685" },
                new Country() { countryId = 186, countryCode = "SMR", countryName = "SanMarino", callingCode = "378" },
                new Country() { countryId = 187, countryCode = "STP", countryName = "SaoTomeandPrincipe", callingCode = "239" },
                new Country() { countryId = 188, countryCode = "SAU", countryName = "SaudiArabia", callingCode = "966" },
                new Country() { countryId = 189, countryCode = "SEN", countryName = "Senegal", callingCode = "221" },
                new Country() { countryId = 190, countryCode = "SRB", countryName = "Serbia", callingCode = "381" },
                new Country() { countryId = 191, countryCode = "SYC", countryName = "Seychelles", callingCode = "248" },
                new Country() { countryId = 192, countryCode = "SLE", countryName = "SierraLeone", callingCode = "232" },
                new Country() { countryId = 193, countryCode = "SGP", countryName = "Singapore", callingCode = "65" },
                new Country() { countryId = 194, countryCode = "SXM", countryName = "SintMaarten", callingCode = "1-721" },
                new Country() { countryId = 195, countryCode = "SVK", countryName = "Slovakia", callingCode = "421" },
                new Country() { countryId = 196, countryCode = "SVN", countryName = "Slovenia", callingCode = "386" },
                new Country() { countryId = 197, countryCode = "SLB", countryName = "SolomonIslands", callingCode = "677" },
                new Country() { countryId = 198, countryCode = "SOM", countryName = "Somalia", callingCode = "252" },
                new Country() { countryId = 199, countryCode = "ZAF", countryName = "SouthAfrica", callingCode = "27" },
                new Country() { countryId = 200, countryCode = "KOR", countryName = "SouthKorea", callingCode = "82" },
                new Country() { countryId = 201, countryCode = "SSD", countryName = "SouthSudan", callingCode = "211" },
                new Country() { countryId = 202, countryCode = "ESP", countryName = "Spain", callingCode = "34" },
                new Country() { countryId = 203, countryCode = "LKA", countryName = "SriLanka", callingCode = "94" },
                new Country() { countryId = 204, countryCode = "SDN", countryName = "Sudan", callingCode = "249" },
                new Country() { countryId = 205, countryCode = "SUR", countryName = "Suriname", callingCode = "597" },
                new Country() { countryId = 206, countryCode = "SJM", countryName = "SvalbardandJanMayen", callingCode = "47" },
                new Country() { countryId = 207, countryCode = "SWZ", countryName = "Swaziland", callingCode = "268" },
                new Country() { countryId = 208, countryCode = "SWE", countryName = "Sweden", callingCode = "46" },
                new Country() { countryId = 209, countryCode = "CHE", countryName = "Switzerland", callingCode = "41" },
                new Country() { countryId = 210, countryCode = "SYR", countryName = "Syria", callingCode = "963" },
                new Country() { countryId = 211, countryCode = "TWN", countryName = "Taiwan", callingCode = "886" },
                new Country() { countryId = 212, countryCode = "TJK", countryName = "Tajikistan", callingCode = "992" },
                new Country() { countryId = 213, countryCode = "TZA", countryName = "Tanzania", callingCode = "255" },
                new Country() { countryId = 214, countryCode = "THA", countryName = "Thailand", callingCode = "66" },
                new Country() { countryId = 215, countryCode = "TGO", countryName = "Togo", callingCode = "228" },
                new Country() { countryId = 216, countryCode = "TKL", countryName = "Tokelau", callingCode = "690" },
                new Country() { countryId = 217, countryCode = "TON", countryName = "Tonga", callingCode = "676" },
                new Country() { countryId = 218, countryCode = "TTO", countryName = "TrinidadandTobago", callingCode = "1-868" },
                new Country() { countryId = 219, countryCode = "TUN", countryName = "Tunisia", callingCode = "216" },
                new Country() { countryId = 220, countryCode = "TUR", countryName = "Turkey", callingCode = "90" },
                new Country() { countryId = 221, countryCode = "TKM", countryName = "Turkmenistan", callingCode = "993" },
                new Country() { countryId = 222, countryCode = "TCA", countryName = "TurksandCaicosIslands", callingCode = "649" },
                new Country() { countryId = 223, countryCode = "TUV", countryName = "Tuvalu", callingCode = "688" },
                new Country() { countryId = 224, countryCode = "VIR", countryName = "U.S.VirginIslands", callingCode = "1-340" },
                new Country() { countryId = 225, countryCode = "UGA", countryName = "Uganda", callingCode = "256" },
                new Country() { countryId = 226, countryCode = "UKR", countryName = "Ukraine", callingCode = "380" },
                new Country() { countryId = 227, countryCode = "ARE", countryName = "UnitedArabEmirates", callingCode = "971" },
                new Country() { countryId = 228, countryCode = "GBR", countryName = "UnitedKingdom", callingCode = "44" },
                new Country() { countryId = 229, countryCode = "USA", countryName = "UnitedStates", callingCode = "1" },
                new Country() { countryId = 230, countryCode = "URY", countryName = "Uruguay", callingCode = "598" },
                new Country() { countryId = 231, countryCode = "UZB", countryName = "Uzbekistan", callingCode = "998" },
                new Country() { countryId = 232, countryCode = "VUT", countryName = "Vanuatu", callingCode = "678" },
                new Country() { countryId = 233, countryCode = "VAT", countryName = "Vatican", callingCode = "379" },
                new Country() { countryId = 234, countryCode = "VEN", countryName = "Venezuela", callingCode = "58" },
                new Country() { countryId = 235, countryCode = "VNM", countryName = "Vietnam", callingCode = "84" },
                new Country() { countryId = 236, countryCode = "WLF", countryName = "WallisandFutuna", callingCode = "681" },
                new Country() { countryId = 237, countryCode = "ESH", countryName = "WesternSahara", callingCode = "212" },
                new Country() { countryId = 238, countryCode = "YEM", countryName = "Yemen", callingCode = "967" },
                new Country() { countryId = 239, countryCode = "ZMB", countryName = "Zambia", callingCode = "260" },
                new Country() { countryId = 240, countryCode = "ZWE", countryName = "Zimbabwe", callingCode = "263" }

            );

            modelBuilder.Entity<State>().HasData(
                new State() { stateId = 1, stateName = "Abu Dhabi", countryId = 227 },
                new State() { stateId = 2, stateName = "Ajman", countryId = 227 },
                new State() { stateId = 3, stateName = "Sharjah", countryId = 227 },
                new State() { stateId = 4, stateName = "Dubai", countryId = 227 },
                new State() { stateId = 5, stateName = "Fujairah", countryId = 227 },
                new State() { stateId = 6, stateName = "Ras Al Khaimah", countryId = 227 },
                new State() { stateId = 7, stateName = "Umm Al Quwain", countryId = 227 }

            );

            modelBuilder.Entity<Company>().HasData(
                new Company() { id = 1, companyCode = "Ascend", name = "AscendOnCloud", email = "ascendoncloud@gmail.com", phoneNumber = "", address = "India", countryId = 95 }
            );



            modelBuilder.Entity<Currency>().HasData(
                new Currency() { currencyId = 1, currencyCode = "INR", currencyName = "Indian Rupee", currencySymbol = "₹" },
                new Currency() { currencyId = 2, currencyCode = "DH", currencyName = "United Arab Emirates dirham", currencySymbol = "فلس" }
            );

            modelBuilder.Entity<Department>().HasData(
              new Department() { departmentId = 1, departmentName = "Administration", companyId = 1, departmentCode = "Admin" }
            );

            // Designation

            modelBuilder.Entity<Designation>().HasData(
              new Designation() { designationId = 1, designationName = "Admin", companyId = 1 },
              new Designation() { designationId = 2, designationName = "User", companyId = 1 }
            );

            // Permission for application

            modelBuilder.Entity<Permission>().HasData(
                new Permission() { permissionId = 1, permissionCode = "BRAND", permissionName = "Brand" },
                new Permission() { permissionId = 2, permissionCode = "CATEGORY", permissionName = "Category" }
                );


            modelBuilder.Entity<DesignationPermission>().HasData(
                // Admin permission seed data
                new DesignationPermission() { designationPermissionId = 1, designationId = 1, permissionId = 1, companyId = 1 },
                new DesignationPermission() { designationPermissionId = 2, designationId = 1, permissionId = 2, companyId = 1 },

                // User permission seed data
                new DesignationPermission() { designationPermissionId = 11, designationId = 2, permissionId = 1, companyId = 1 },
                new DesignationPermission() { designationPermissionId = 12, designationId = 2, permissionId = 2, companyId = 1 }
            );


            modelBuilder.Entity<User>().HasData(
            new User()
            {
                userId = 1,
                userCode = "ASND001",
                email = "admin@gmail.com",
                firstName = "Super",
                lastName = "Admin",
                nativeName = "مشرف",
                phoneNumber = "9876543210",
                userPassword = "admin",
                gender = "male",
                doj = DateTime.Now,
                dob = DateTime.Now,
                designationId = 1,
                departmentId = 1,
                companyId = 1,
                nationality = 95
            },
            new User()
            {
                userId = 2,
                userCode = "ASND002",
                email = "user@gmail.com",
                firstName = "Normal",
                lastName = "User",
                nativeName = "مشرف",
                phoneNumber = "9876543210",
                userPassword = "user",
                gender = "male",
                doj = DateTime.Now,
                dob = DateTime.Now,
                designationId = 2,
                departmentId = 1,
                companyId = 1,
                nationality = 95
            }
        );

            modelBuilder.Entity<Uom>().HasData(
               new Uom() { uomId = 1, uomName = "Litter" },
               new Uom() { uomId = 2, uomName = "Kg" }
           );
        }
    }
}