using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Infrastructure.Data.Migrations
{
    public partial class ArtifactImproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.AddColumn<int>(
                name: "PurchasedQuantity",
                table: "StudentArtifact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Artifact",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description", "Name", "Quantity", "Type" },
                values: new object[] { 792, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Sleek Fresh Cheese", null, "Extra" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 952, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Handmade Soft Table", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 603, "The Football Is Good For Training And Recreational Purposes", "Awesome Steel Towels", 8 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description", "Name", "Quantity", "Type" },
                values: new object[] { 364, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Fantastic Fresh Bacon", 6, "Extra" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 221, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Intelligent Rubber Bacon", 3 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Description", "Name", "Type" },
                values: new object[] { 231, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Sleek Metal Towels", "Extra" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Description", "Name", "Type" },
                values: new object[] { 986, "The Football Is Good For Training And Recreational Purposes", "Handcrafted Cotton Keyboard", "Extra" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 619, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Intelligent Granite Ball", 4 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 180, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Refined Fresh Hat", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description", "Name", "Quantity", "Type" },
                values: new object[] { 178, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Fantastic Cotton Car", null, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Wooden Fish", 181 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Sleek Metal Bike", 112, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Reward" },
                values: new object[] { "Refined Frozen Pants", 966 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Gorgeous Rubber Mouse", 524, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Reward" },
                values: new object[] { "Ergonomic Wooden Car", 964 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Small Metal Tuna", 236, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Ergonomic Concrete Towels", 259, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The Football Is Good For Training And Recreational Purposes", "Tasty Granite Towels", 566 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Unbranded Metal Bike", 880, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The Football Is Good For Training And Recreational Purposes", "Generic Metal Soap", 996 });

            migrationBuilder.UpdateData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 1 },
                column: "PurchasedQuantity",
                value: 8);

            migrationBuilder.InsertData(
                table: "StudentArtifact",
                columns: new[] { "StudentId", "ArtifactId", "PurchasedQuantity" },
                values: new object[,]
                {
                    { 10, 5, 3 },
                    { 2, 4, 1 },
                    { 1, 10, 4 },
                    { 4, 6, 6 },
                    { 10, 10, 8 },
                    { 7, 4, 10 },
                    { 2, 2, 5 },
                    { 7, 8, 1 },
                    { 4, 3, 6 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "The RSS monitor is down, copy the online monitor so we can copy the RSS monitor!", "Tricia.Bailey4@yahoo.com", "Tricia", "Bailey", 825 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "I'll quantify the open-source COM program, that should program the COM program!", "Monique_Morar@yahoo.com", "Monique", "Morar", 219 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the primary SCSI alarm, then you can quantify the primary alarm!", "Claire.White@hotmail.com", "Claire", "White", 392 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't copy the array without navigating the neural USB array!", "William_Becker@hotmail.com", "William", "Becker", 633 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Try to index the EXE bus, maybe it will index the online bus!", "Johnathan_Hyatt13@yahoo.com", "Johnathan", "Hyatt", 609 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the 1080p XSS microchip, then you can navigate the 1080p microchip!", "Alfredo_Legros@hotmail.com", "Alfredo", "Legros", 722 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "bypassing the firewall won't do anything, we need to generate the back-end RSS firewall!", "Darlene93@hotmail.com", "Darlene", "Becker", 582 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "transmitting the monitor won't do anything, we need to compress the wireless JSON monitor!", "Edna.Heidenreich46@yahoo.com", "Edna", "Heidenreich", 51 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "I'll bypass the 1080p SAS firewall, that should firewall the SAS firewall!", "Julie_Metz65@gmail.com", "Julie", "Metz", 14 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to reboot the neural PNG interface!", "Susan_Lemke5@gmail.com", "Susan", "Lemke", 277 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DropColumn(
                name: "PurchasedQuantity",
                table: "StudentArtifact");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Artifact");

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 895, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Frozen Table", 8 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 912, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Generic Soft Shirt", 7 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 998, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Fantastic Fresh Mouse", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 454, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Unbranded Plastic Chips", 7 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 124, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Generic Fresh Pants", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 907, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Handmade Fresh Cheese" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 289, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Awesome Frozen Cheese" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 343, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Refined Soft Bacon", 0 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 59, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Granite Chicken", 10 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 819, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Unbranded Steel Tuna", 3 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Incredible Plastic Ball", 21 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Generic Cotton Computer", 133, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Reward" },
                values: new object[] { "Tasty Rubber Chicken", 988 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Incredible Steel Computer", 337, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Reward" },
                values: new object[] { "Sleek Fresh Bike", 10 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Practical Cotton Table", 805, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Gorgeous Steel Car", 680, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Intelligent Concrete Tuna", 716 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Incredible Steel Salad", 737, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Handcrafted Fresh Sausages", 952 });

            migrationBuilder.InsertData(
                table: "StudentArtifact",
                columns: new[] { "StudentId", "ArtifactId" },
                values: new object[,]
                {
                    { 2, 9 },
                    { 5, 6 },
                    { 2, 6 },
                    { 3, 9 },
                    { 10, 9 },
                    { 2, 7 },
                    { 5, 4 },
                    { 1, 3 },
                    { 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "If we reboot the port, we can get to the COM port through the wireless COM port!", "Reginald.Sipes@gmail.com", "Reginald", "Sipes", 844 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "I'll compress the optical PCI driver, that should driver the PCI driver!", "Tamara59@gmail.com", "Tamara", "Blanda", 959 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the redundant SCSI pixel, then you can index the redundant pixel!", "Sarah65@gmail.com", "Sarah", "Hintz", 965 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "I'll parse the digital CSS bus, that should bus the CSS bus!", "Violet.Gutkowski@gmail.com", "Violet", "Gutkowski", 819 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't compress the capacitor without transmitting the back-end SCSI capacitor!", "Lana42@yahoo.com", "Lana", "Quigley", 406 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "I'll quantify the multi-byte CSS microchip, that should microchip the CSS microchip!", "Pablo16@yahoo.com", "Pablo", "Wilderman", 154 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "If we quantify the matrix, we can get to the JBOD matrix through the neural JBOD matrix!", "Rose.Berge95@hotmail.com", "Rose", "Berge", 436 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't generate the application without programming the digital SMS application!", "Lloyd73@yahoo.com", "Lloyd", "Rolfson", 267 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to hack the back-end SSL protocol!", "Otis_Dooley15@yahoo.com", "Otis", "Dooley", 544 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "I'll generate the online ADP capacitor, that should capacitor the ADP capacitor!", "Antonia.Mitchell@gmail.com", "Antonia", "Mitchell", 200 });
        }
    }
}
