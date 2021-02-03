using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ascend.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    countryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    countryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    callingCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    currencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currencyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    currencyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    currencySymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.currencyId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    permissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    permissionCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.permissionId);
                });

            migrationBuilder.CreateTable(
                name: "Uom",
                columns: table => new
                {
                    uomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uom", x => x.uomId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    countryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                    table.ForeignKey(
                        name: "FK_Company_Country_countryId",
                        column: x => x.countryId,
                        principalTable: "Country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    stateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.stateId);
                    table.ForeignKey(
                        name: "FK_State_Country_countryId",
                        column: x => x.countryId,
                        principalTable: "Country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    designationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.designationId);
                    table.ForeignKey(
                        name: "FK_Designation_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesignationPermission",
                columns: table => new
                {
                    designationPermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designationId = table.Column<int>(type: "int", nullable: true),
                    permissionId = table.Column<int>(type: "int", nullable: true),
                    companyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationPermission", x => x.designationPermissionId);
                    table.ForeignKey(
                        name: "FK_DesignationPermission_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesignationPermission_Designation_designationId",
                        column: x => x.designationId,
                        principalTable: "Designation",
                        principalColumn: "designationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DesignationPermission_Permission_permissionId",
                        column: x => x.permissionId,
                        principalTable: "Permission",
                        principalColumn: "permissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    departmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userCreated = table.Column<int>(type: "int", nullable: true),
                    userModified = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.departmentId);
                    table.ForeignKey(
                        name: "FK_Department_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPassword = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    nationality = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: true),
                    designationId = table.Column<int>(type: "int", nullable: true),
                    countryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                    table.ForeignKey(
                        name: "FK_User_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Country_countryId",
                        column: x => x.countryId,
                        principalTable: "Country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Designation_designationId",
                        column: x => x.designationId,
                        principalTable: "Designation",
                        principalColumn: "designationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "countryId", "callingCode", "countryCode", "countryName" },
                values: new object[,]
                {
                    { 1, "93", "AFG", "Afghanistan" },
                    { 154, "234", "NGA", "Nigeria" },
                    { 155, "683", "NIU", "Niue" },
                    { 156, "850", "PRK", "NorthKorea" },
                    { 157, "1-670", "MNP", "NorthernMarianaIslands" },
                    { 158, "47", "NOR", "Norway" },
                    { 159, "968", "OMN", "Oman" },
                    { 160, "92", "PAK", "Pakistan" },
                    { 161, "680", "PLW", "Palau" },
                    { 162, "970", "PSE", "Palestine" },
                    { 163, "507", "PAN", "Panama" },
                    { 164, "675", "PNG", "PapuaNewGuinea" },
                    { 165, "595", "PRY", "Paraguay" },
                    { 153, "227", "NER", "Niger" },
                    { 166, "51", "PER", "Peru" },
                    { 168, "64", "PCN", "Pitcairn" },
                    { 169, "48", "POL", "Poland" },
                    { 170, "351", "PRT", "Portugal" },
                    { 171, "1-787", "PRI", "PuertoRico" },
                    { 172, "974", "QAT", "Qatar" },
                    { 173, "242", "COG", "RepublicoftheCongo" },
                    { 174, "262", "REU", "Reunion" },
                    { 175, "40", "ROU", "Romania" },
                    { 176, "7", "RUS", "Russia" },
                    { 177, "250", "RWA", "Rwanda" },
                    { 178, "590", "BLM", "SaintBarthelemy" },
                    { 179, "290", "SHN", "SaintHelena" },
                    { 167, "63", "PHL", "Philippines" },
                    { 180, "1-869", "KNA", "SaintKittsandNevis" },
                    { 152, "505", "NIC", "Nicaragua" },
                    { 150, "687", "NCL", "NewCaledonia" },
                    { 124, "389", "MKD", "Macedonia" },
                    { 125, "261", "MDG", "Madagascar" },
                    { 126, "265", "MWI", "Malawi" },
                    { 127, "60", "MYS", "Malaysia" },
                    { 128, "960", "MDV", "Maldives" },
                    { 129, "223", "MLI", "Mali" },
                    { 130, "356", "MLT", "Malta" },
                    { 131, "692", "MHL", "MarshallIslands" },
                    { 132, "222", "MRT", "Mauritania" },
                    { 133, "230", "MUS", "Mauritius" },
                    { 134, "262", "MYT", "Mayotte" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "countryId", "callingCode", "countryCode", "countryName" },
                values: new object[,]
                {
                    { 135, "52", "MEX", "Mexico" },
                    { 151, "64", "NZL", "NewZealand" },
                    { 136, "691", "FSM", "Micronesia" },
                    { 138, "377", "MCO", "Monaco" },
                    { 139, "976", "MNG", "Mongolia" },
                    { 140, "382", "MNE", "Montenegro" },
                    { 141, "1-664", "MSR", "Montserrat" },
                    { 142, "212", "MAR", "Morocco" },
                    { 143, "258", "MOZ", "Mozambique" },
                    { 144, "95", "MMR", "Myanmar" },
                    { 145, "264", "NAM", "Namibia" },
                    { 146, "674", "NRU", "Nauru" },
                    { 147, "977", "NPL", "Nepal" },
                    { 148, "31", "NLD", "Netherlands" },
                    { 149, "599", "ANT", "NetherlandsAntilles" },
                    { 137, "373", "MDA", "Moldova" },
                    { 181, "1-758", "LCA", "SaintLucia" },
                    { 182, "590", "MAF", "SaintMartin" },
                    { 183, "508", "SPM", "SaintPierreandMiquelon" },
                    { 215, "228", "TGO", "Togo" },
                    { 216, "690", "TKL", "Tokelau" },
                    { 217, "676", "TON", "Tonga" },
                    { 218, "1-868", "TTO", "TrinidadandTobago" },
                    { 219, "216", "TUN", "Tunisia" },
                    { 220, "90", "TUR", "Turkey" },
                    { 221, "993", "TKM", "Turkmenistan" },
                    { 222, "649", "TCA", "TurksandCaicosIslands" },
                    { 223, "688", "TUV", "Tuvalu" },
                    { 224, "1-340", "VIR", "U.S.VirginIslands" },
                    { 225, "256", "UGA", "Uganda" },
                    { 226, "380", "UKR", "Ukraine" },
                    { 214, "66", "THA", "Thailand" },
                    { 227, "971", "ARE", "UnitedArabEmirates" },
                    { 229, "1", "USA", "UnitedStates" },
                    { 230, "598", "URY", "Uruguay" },
                    { 231, "998", "UZB", "Uzbekistan" },
                    { 232, "678", "VUT", "Vanuatu" },
                    { 233, "379", "VAT", "Vatican" },
                    { 234, "58", "VEN", "Venezuela" },
                    { 235, "84", "VNM", "Vietnam" },
                    { 236, "681", "WLF", "WallisandFutuna" },
                    { 237, "212", "ESH", "WesternSahara" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "countryId", "callingCode", "countryCode", "countryName" },
                values: new object[,]
                {
                    { 238, "967", "YEM", "Yemen" },
                    { 239, "260", "ZMB", "Zambia" },
                    { 240, "263", "ZWE", "Zimbabwe" },
                    { 228, "44", "GBR", "UnitedKingdom" },
                    { 213, "255", "TZA", "Tanzania" },
                    { 212, "992", "TJK", "Tajikistan" },
                    { 211, "886", "TWN", "Taiwan" },
                    { 184, "1-784", "VCT", "SaintVincentandtheGrenadines" },
                    { 185, "685", "WSM", "Samoa" },
                    { 186, "378", "SMR", "SanMarino" },
                    { 187, "239", "STP", "SaoTomeandPrincipe" },
                    { 188, "966", "SAU", "SaudiArabia" },
                    { 189, "221", "SEN", "Senegal" },
                    { 190, "381", "SRB", "Serbia" },
                    { 191, "248", "SYC", "Seychelles" },
                    { 192, "232", "SLE", "SierraLeone" },
                    { 193, "65", "SGP", "Singapore" },
                    { 194, "1-721", "SXM", "SintMaarten" },
                    { 195, "421", "SVK", "Slovakia" },
                    { 196, "386", "SVN", "Slovenia" },
                    { 197, "677", "SLB", "SolomonIslands" },
                    { 198, "252", "SOM", "Somalia" },
                    { 199, "27", "ZAF", "SouthAfrica" },
                    { 200, "82", "KOR", "SouthKorea" },
                    { 201, "211", "SSD", "SouthSudan" },
                    { 202, "34", "ESP", "Spain" },
                    { 203, "94", "LKA", "SriLanka" },
                    { 204, "249", "SDN", "Sudan" },
                    { 205, "597", "SUR", "Suriname" },
                    { 206, "47", "SJM", "SvalbardandJanMayen" },
                    { 207, "268", "SWZ", "Swaziland" },
                    { 208, "46", "SWE", "Sweden" },
                    { 209, "41", "CHE", "Switzerland" },
                    { 210, "963", "SYR", "Syria" },
                    { 122, "352", "LUX", "Luxembourg" },
                    { 121, "370", "LTU", "Lithuania" },
                    { 123, "853", "MAC", "Macao" },
                    { 119, "218", "LBY", "Libya" },
                    { 33, "359", "BGR", "Bulgaria" },
                    { 34, "226", "BFA", "BurkinaFaso" },
                    { 35, "257", "BDI", "Burundi" },
                    { 36, "855", "KHM", "Cambodia" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "countryId", "callingCode", "countryCode", "countryName" },
                values: new object[,]
                {
                    { 37, "237", "CMR", "Cameroon" },
                    { 38, "1", "CAN", "Canada" },
                    { 39, "238", "CPV", "CapeVerde" },
                    { 40, "1-345", "CYM", "CaymanIslands" },
                    { 41, "236", "CAF", "CentralAfricanRepublic" },
                    { 42, "235", "TCD", "Chad" },
                    { 43, "56", "CHL", "Chile" },
                    { 44, "86", "CHN", "China" },
                    { 32, "673", "BRN", "Brunei" },
                    { 45, "61", "CXR", "ChristmasIsland" },
                    { 47, "57", "COL", "Colombia" },
                    { 48, "269", "COM", "Comoros" },
                    { 49, "682", "COK", "CookIslands" },
                    { 50, "506", "CRI", "CostaRica" },
                    { 51, "385", "HRV", "Croatia" },
                    { 52, "53", "CUB", "Cuba" },
                    { 53, "599", "CUW", "Curacao" },
                    { 54, "357", "CYP", "Cyprus" },
                    { 55, "420", "CZE", "CzechRepublic" },
                    { 56, "243", "COD", "DemocraticRepublicoftheCongo" },
                    { 57, "45", "DNK", "Denmark" },
                    { 120, "423", "LIE", "Liechtenstein" },
                    { 46, "61", "CCK", "CocosIslands" },
                    { 31, "1-284", "VGB", "BritishVirginIslands" },
                    { 30, "246", "IOT", "BritishIndianOceanTerritory" },
                    { 29, "55", "BRA", "Brazil" },
                    { 2, "355", "ALB", "Albania" },
                    { 3, "213", "DZA", "Algeria" },
                    { 4, "1-684", "ASM", "AmericanSamoa" },
                    { 5, "376", "AND", "Andorra" },
                    { 6, "244", "AGO", "Angola" },
                    { 7, "1-264", "AIA", "Anguilla" },
                    { 8, "672", "ATA", "Antarctica" },
                    { 9, "1-268", "ATG", "AntiguaandBarbuda" },
                    { 10, "54", "ARG", "Argentina" },
                    { 11, "374", "ARM", "Armenia" },
                    { 12, "297", "ABW", "Aruba" },
                    { 13, "61", "AUS", "Australia" },
                    { 14, "43", "AUT", "Austria" },
                    { 15, "994", "AZE", "Azerbaijan" },
                    { 16, "1-242", "BHS", "Bahamas" },
                    { 17, "973", "BHR", "Bahrain" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "countryId", "callingCode", "countryCode", "countryName" },
                values: new object[,]
                {
                    { 18, "880", "BGD", "Bangladesh" },
                    { 19, "1-246", "BRB", "Barbados" },
                    { 20, "375", "BLR", "Belarus" },
                    { 21, "32", "BEL", "Belgium" },
                    { 22, "501", "BLZ", "Belize" },
                    { 23, "229", "BEN", "Benin" },
                    { 24, "1-441", "BMU", "Bermuda" },
                    { 25, "975", "BTN", "Bhutan" },
                    { 26, "591", "BOL", "Bolivia" },
                    { 27, "387", "BIH", "BosniaandHerzegovina" },
                    { 28, "267", "BWA", "Botswana" },
                    { 59, "1-767", "DMA", "Dominica" },
                    { 60, "1-809", "DOM", "DominicanRepublic" },
                    { 58, "253", "DJI", "Djibouti" },
                    { 62, "593", "ECU", "Ecuador" },
                    { 61, "670", "TLS", "EastTimor" },
                    { 94, "354", "ISL", "Iceland" },
                    { 95, "91", "IND", "India" },
                    { 96, "62", "IDN", "Indonesia" },
                    { 97, "98", "IRN", "Iran" },
                    { 98, "964", "IRQ", "Iraq" },
                    { 99, "353", "IRL", "Ireland" },
                    { 100, "1624", "IMN", "IsleofMan" },
                    { 101, "972", "ISR", "Israel" },
                    { 102, "39", "ITA", "Italy" },
                    { 103, "225", "CIV", "IvoryCoast" },
                    { 104, "1-876", "JAM", "Jamaica" },
                    { 92, "852", "HKG", "HongKong" },
                    { 105, "81", "JPN", "Japan" },
                    { 107, "962", "JOR", "Jordan" },
                    { 108, "7", "KAZ", "Kazakhstan" },
                    { 109, "254", "KEN", "Kenya" },
                    { 110, "686", "KIR", "Kiribati" },
                    { 111, "383", "XKX", "Kosovo" },
                    { 112, "965", "KWT", "Kuwait" },
                    { 113, "996", "KGZ", "Kyrgyzstan" },
                    { 114, "856", "LAO", "Laos" },
                    { 115, "371", "LVA", "Latvia" },
                    { 116, "961", "LBN", "Lebanon" },
                    { 117, "266", "LSO", "Lesotho" },
                    { 118, "231", "LBR", "Liberia" },
                    { 106, "1534", "JEY", "Jersey" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "countryId", "callingCode", "countryCode", "countryName" },
                values: new object[,]
                {
                    { 91, "504", "HND", "Honduras" },
                    { 93, "36", "HUN", "Hungary" },
                    { 89, "592", "GUY", "Guyana" },
                    { 63, "20", "EGY", "Egypt" },
                    { 64, "503", "SLV", "ElSalvador" },
                    { 65, "240", "GNQ", "EquatorialGuinea" },
                    { 66, "291", "ERI", "Eritrea" },
                    { 67, "372", "EST", "Estonia" },
                    { 68, "251", "ETH", "Ethiopia" },
                    { 69, "500", "FLK", "FalklandIslands" },
                    { 70, "298", "FRO", "FaroeIslands" },
                    { 71, "679", "FJI", "Fiji" },
                    { 72, "358", "FIN", "Finland" },
                    { 90, "509", "HTI", "Haiti" },
                    { 74, "689", "PYF", "FrenchPolynesia" },
                    { 75, "241", "GAB", "Gabon" },
                    { 73, "33", "FRA", "France" },
                    { 77, "995", "GEO", "Georgia" },
                    { 88, "245", "GNB", "Guinea-Bissau" },
                    { 87, "224", "GIN", "Guinea" },
                    { 76, "220", "GMB", "Gambia" },
                    { 85, "502", "GTM", "Guatemala" },
                    { 84, "1-671", "GUM", "Guam" },
                    { 86, "1481", "GGY", "Guernsey" },
                    { 82, "299", "GRL", "Greenland" },
                    { 81, "30", "GRC", "Greece" },
                    { 80, "350", "GIB", "Gibraltar" },
                    { 79, "233", "GHA", "Ghana" },
                    { 78, "49", "DEU", "Germany" },
                    { 83, "1-473", "GRD", "Grenada" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "currencyId", "currencyCode", "currencyName", "currencySymbol" },
                values: new object[,]
                {
                    { 1, "INR", "Indian Rupee", "₹" },
                    { 2, "DH", "United Arab Emirates dirham", "فلس" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "permissionId", "permissionCode", "permissionName" },
                values: new object[,]
                {
                    { 1, "BRAND", "Brand" },
                    { 2, "CATEGORY", "Category" }
                });

            migrationBuilder.InsertData(
                table: "Uom",
                columns: new[] { "uomId", "uomName" },
                values: new object[,]
                {
                    { 1, "Litter" },
                    { 2, "Kg" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "id", "address", "companyCode", "countryId", "email", "name", "phoneNumber" },
                values: new object[] { 1, "India", "Ascend", 95, "ascendoncloud@gmail.com", "AscendOnCloud", "" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "stateId", "countryId", "stateName" },
                values: new object[,]
                {
                    { 1, 227, "Abu Dhabi" },
                    { 2, 227, "Ajman" },
                    { 3, 227, "Sharjah" },
                    { 4, 227, "Dubai" },
                    { 5, 227, "Fujairah" },
                    { 6, 227, "Ras Al Khaimah" },
                    { 7, 227, "Umm Al Quwain" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "departmentId", "companyId", "dateCreated", "dateModified", "departmentCode", "departmentName", "isDelete", "userCreated", "userModified" },
                values: new object[] { 1, 1, new DateTime(2021, 2, 2, 18, 41, 49, 189, DateTimeKind.Local).AddTicks(7259), null, "Admin", "Administration", false, null, null });

            migrationBuilder.InsertData(
                table: "Designation",
                columns: new[] { "designationId", "companyId", "designationName" },
                values: new object[] { 1, 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Designation",
                columns: new[] { "designationId", "companyId", "designationName" },
                values: new object[] { 2, 1, "User" });

            migrationBuilder.InsertData(
                table: "DesignationPermission",
                columns: new[] { "designationPermissionId", "companyId", "designationId", "permissionId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 11, 1, 2, 1 },
                    { 12, 1, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "companyId", "countryId", "departmentId", "designationId", "dob", "doj", "email", "firstName", "gender", "lastName", "nationality", "nativeName", "phoneNumber", "userCode", "userPassword" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1, new DateTime(2021, 2, 2, 18, 41, 49, 193, DateTimeKind.Local).AddTicks(7302), new DateTime(2021, 2, 2, 18, 41, 49, 193, DateTimeKind.Local).AddTicks(6653), "admin@gmail.com", "Super", "male", "Admin", 95, "مشرف", "9876543210", "ASND001", "admin" },
                    { 2, 1, null, 1, 2, new DateTime(2021, 2, 2, 18, 41, 49, 194, DateTimeKind.Local).AddTicks(527), new DateTime(2021, 2, 2, 18, 41, 49, 194, DateTimeKind.Local).AddTicks(514), "user@gmail.com", "Normal", "male", "User", 95, "مشرف", "9876543210", "ASND002", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_countryId",
                table: "Company",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_companyId",
                table: "Department",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_userCreated",
                table: "Department",
                column: "userCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_companyId",
                table: "Designation",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationPermission_companyId",
                table: "DesignationPermission",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationPermission_designationId",
                table: "DesignationPermission",
                column: "designationId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationPermission_permissionId",
                table: "DesignationPermission",
                column: "permissionId");

            migrationBuilder.CreateIndex(
                name: "IX_State_countryId",
                table: "State",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_companyId",
                table: "User",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_countryId",
                table: "User",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_departmentId",
                table: "User",
                column: "departmentId",
                unique: true,
                filter: "[departmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_designationId",
                table: "User",
                column: "designationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_userCreated",
                table: "Department",
                column: "userCreated",
                principalTable: "User",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_countryId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Country_countryId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company_companyId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Designation_Company_companyId",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Company_companyId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_userCreated",
                table: "Department");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DesignationPermission");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Uom");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Designation");
        }
    }
}
