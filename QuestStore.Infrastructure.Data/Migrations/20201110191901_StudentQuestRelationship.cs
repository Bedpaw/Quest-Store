using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Infrastructure.Data.Migrations
{
    public partial class StudentQuestRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 1, 1 });

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
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "User",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Quest",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Classroom",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Artifact",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StudentQuest",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    QuestId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuest", x => new { x.StudentId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_StudentQuest_Quest_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuest_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 685, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Handcrafted Soft Car", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 49, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Intelligent Concrete Salad" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 238, "The Football Is Good For Training And Recreational Purposes", "Handmade Soft Pizza", null });

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
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 354, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Generic Metal Shirt", 8 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 635, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Rustic Fresh Cheese", 0 });

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
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 858, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Fantastic Fresh Car" });

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
                columns: new[] { "Name", "Reward", "Type" },
                values: new object[] { "Generic Rubber Car", 931, "Extra" });

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
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Handmade Rubber Shirt", 270 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Fantastic Steel Gloves", 530, "Basic" });

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuest_QuestId",
                table: "StudentQuest",
                column: "QuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentQuest");

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

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "User",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Quest",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Classroom",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Artifact",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 799, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Ergonomic Fresh Bike", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 3, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Sleek Soft Cheese", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 509, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Gorgeous Frozen Cheese", 5 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 233, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Generic Fresh Pants" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 509, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Incredible Soft Keyboard", 1 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 48, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Small Concrete Pants", 10 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 133, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Rustic Steel Tuna", 7 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 631, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Awesome Plastic Shoes", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 729, "The Football Is Good For Training And Recreational Purposes", "Ergonomic Fresh Pants", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 931, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Tasty Rubber Shoes" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Practical Wooden Sausages", 247, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Awesome Cotton Chicken", 440 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Fantastic Rubber Keyboard", 632, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Handmade Concrete Shirt", 898, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Reward", "Type" },
                values: new object[] { "Refined Soft Hat", 208, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Practical Concrete Chair", 871, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Unbranded Rubber Towels", 935 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Awesome Wooden Bike", 191 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Refined Fresh Tuna", 789, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Awesome Wooden Bike", 119 });

            migrationBuilder.InsertData(
                table: "StudentArtifact",
                columns: new[] { "StudentId", "ArtifactId" },
                values: new object[,]
                {
                    { 6, 9 },
                    { 3, 7 },
                    { 2, 2 },
                    { 4, 2 },
                    { 10, 9 },
                    { 1, 1 },
                    { 9, 4 },
                    { 1, 10 },
                    { 4, 5 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Try to quantify the SQL circuit, maybe it will quantify the online circuit!", "Lucy_Kerluke@hotmail.com", "Lucy", "Kerluke", 170 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't index the alarm without hacking the cross-platform SMTP alarm!", "Christy.Pacocha83@gmail.com", "Christy", "Pacocha", 408 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't back up the bus without hacking the redundant EXE bus!", "Dexter31@hotmail.com", "Dexter", "Swift", 801 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Try to index the THX driver, maybe it will index the neural driver!", "Delores.Auer@yahoo.com", "Delores", "Auer", 776 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't input the interface without calculating the 1080p XML interface!", "June94@hotmail.com", "June", "Buckridge", 981 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "parsing the driver won't do anything, we need to input the auxiliary SQL driver!", "Bonnie.Hirthe12@gmail.com", "Bonnie", "Hirthe", 830 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the wireless CSS sensor, then you can parse the wireless sensor!", "Janis.Gleason59@yahoo.com", "Janis", "Gleason", 189 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to generate the virtual PCI circuit!", "Corey.Terry37@gmail.com", "Corey", "Terry", 242 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to hack the 1080p SQL pixel!", "Caroline.Rutherford51@gmail.com", "Caroline", "Rutherford", 712 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the haptic ADP circuit, then you can reboot the haptic circuit!", "Gerardo.Robel29@yahoo.com", "Gerardo", "Robel", 447 });
        }
    }
}
