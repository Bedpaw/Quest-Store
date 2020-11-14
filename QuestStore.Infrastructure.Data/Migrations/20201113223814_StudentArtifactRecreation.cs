using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Infrastructure.Data.Migrations
{
    public partial class StudentArtifactRecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 4 });

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
                columns: new[] { "Cost", "Name" },
                values: new object[] { 998, "Fantastic Fresh Mouse" });

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
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 124, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Generic Fresh Pants" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 907, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Handmade Fresh Cheese", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 289, "Awesome Frozen Cheese", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 343, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Refined Soft Bacon" });

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
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Incredible Plastic Ball", 21, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Generic Cotton Computer", 133 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Football Is Good For Training And Recreational Purposes", "Tasty Rubber Chicken", 988, "Extra" });

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
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Gorgeous Steel Car", 680 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Intelligent Concrete Tuna", 716, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Incredible Steel Salad", 737 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 868, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Intelligent Metal Car", 1 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 343, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Gorgeous Concrete Fish", 5 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Name" },
                values: new object[] { 685, "Handcrafted Soft Car" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 49, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Intelligent Concrete Salad", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 238, "The Football Is Good For Training And Recreational Purposes", "Handmade Soft Pizza" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 243, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Sleek Steel Chicken", 9 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 354, "Generic Metal Shirt", 8 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 635, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Rustic Fresh Cheese" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 806, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Practical Wooden Bacon", 7 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 858, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Fantastic Fresh Car", null });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Handcrafted Rubber Pizza", 982, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Fantastic Frozen Tuna", 993 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Tasty Fresh Table", 206, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Intelligent Fresh Pizza", 670, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Reward" },
                values: new object[] { "Generic Rubber Car", 931 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Unbranded Fresh Table", 674, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The Football Is Good For Training And Recreational Purposes", "Incredible Fresh Chair", 184 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Handmade Rubber Shirt", 270, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Fantastic Steel Gloves", 530 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Unbranded Fresh Salad", 626 });

            migrationBuilder.InsertData(
                table: "StudentArtifact",
                columns: new[] { "StudentId", "ArtifactId" },
                values: new object[,]
                {
                    { 10, 4 },
                    { 5, 3 },
                    { 1, 6 },
                    { 8, 5 },
                    { 6, 3 },
                    { 2, 8 },
                    { 3, 3 },
                    { 4, 7 },
                    { 5, 9 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the neural TCP array, then you can program the neural array!", "Kristen_Kiehn@gmail.com", "Kristen", "Kiehn", 178 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "parsing the hard drive won't do anything, we need to input the neural AGP hard drive!", "Antonio.Collier83@hotmail.com", "Antonio", "Collier", 873 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to back up the wireless IB firewall!", "Lynne_Vandervort80@gmail.com", "Lynne", "Vandervort", 419 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "The SDD card is down, reboot the multi-byte card so we can reboot the SDD card!", "Mabel_Olson12@yahoo.com", "Mabel", "Olson", 943 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "If we calculate the port, we can get to the SMTP port through the online SMTP port!", "Hugo_Yost74@gmail.com", "Hugo", "Yost", 648 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the haptic HTTP alarm, then you can copy the haptic alarm!", "Jay.Runolfsdottir@hotmail.com", "Jay", "Runolfsdottir", 198 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to parse the redundant EXE application!", "Antonia.Legros@gmail.com", "Antonia", "Legros", 609 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the wireless THX alarm, then you can bypass the wireless alarm!", "Ronnie54@yahoo.com", "Ronnie", "Ratke", 801 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to bypass the primary SCSI bus!", "Betty4@hotmail.com", "Betty", "Smith", 774 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "If we bypass the port, we can get to the IB port through the primary IB port!", "Mary.Hodkiewicz38@gmail.com", "Mary", "Hodkiewicz", 288 });
        }
    }
}
