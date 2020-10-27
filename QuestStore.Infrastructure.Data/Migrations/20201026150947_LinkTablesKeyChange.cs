using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Infrastructure.Data.Migrations
{
    public partial class LinkTablesKeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClassroom",
                table: "StudentClassroom");

            migrationBuilder.DropIndex(
                name: "IX_StudentClassroom_StudentId",
                table: "StudentClassroom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentArtifact",
                table: "StudentArtifact");

            migrationBuilder.DropIndex(
                name: "IX_StudentArtifact_StudentId",
                table: "StudentArtifact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorClassroom",
                table: "MentorClassroom");

            migrationBuilder.DropIndex(
                name: "IX_MentorClassroom_MentorId",
                table: "MentorClassroom");

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentClassroom");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentArtifact");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MentorClassroom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClassroom",
                table: "StudentClassroom",
                columns: new[] { "StudentId", "ClassroomId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentArtifact",
                table: "StudentArtifact",
                columns: new[] { "StudentId", "ArtifactId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorClassroom",
                table: "MentorClassroom",
                columns: new[] { "MentorId", "ClassroomId" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 799, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Ergonomic Fresh Bike" });

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
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 48, "Small Concrete Pants", 10 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 133, "Rustic Steel Tuna", 7 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 631, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Awesome Plastic Shoes" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 729, "The Football Is Good For Training And Recreational Purposes", "Ergonomic Fresh Pants" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 931, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Tasty Rubber Shoes", null });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Practical Wooden Sausages", 247 });

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
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Handmade Concrete Shirt", 898 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Refined Soft Hat", 208 });

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
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Refined Fresh Tuna", 789 });

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
                    { 4, 5 },
                    { 9, 4 },
                    { 1, 10 },
                    { 1, 1 },
                    { 6, 9 },
                    { 10, 1 },
                    { 3, 7 },
                    { 2, 2 },
                    { 4, 2 },
                    { 10, 9 }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClassroom",
                table: "StudentClassroom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentArtifact",
                table: "StudentArtifact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorClassroom",
                table: "MentorClassroom");

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
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentClassroom",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentArtifact",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MentorClassroom",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClassroom",
                table: "StudentClassroom",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentArtifact",
                table: "StudentArtifact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorClassroom",
                table: "MentorClassroom",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 502, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Rustic Rubber Soap" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 279, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Rustic Frozen Salad", 4 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 398, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Fantastic Concrete Hat", 9 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 755, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Ergonomic Soft Tuna" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 293, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Handmade Fresh Chips", 6 });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 752, "Awesome Metal Cheese", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 584, "Awesome Plastic Ball", null });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 192, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Practical Fresh Pants" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 239, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Refined Frozen Cheese" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 866, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Ergonomic Fresh Pants", 7 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Generic Wooden Ball", 147 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Awesome Soft Sausages", 467 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Concrete Chicken", 629, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Sleek Granite Towels", 274 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Handmade Steel Tuna", 172 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Licensed Rubber Fish", 294, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Intelligent Plastic Tuna", 168 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Handcrafted Soft Soap", 325 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Granite Sausages", 19 });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Handcrafted Cotton Bacon", 56 });

            migrationBuilder.InsertData(
                table: "StudentArtifact",
                columns: new[] { "Id", "ArtifactId", "StudentId" },
                values: new object[,]
                {
                    { 1, 7, 2 },
                    { 9, 3, 7 },
                    { 10, 1, 3 },
                    { 2, 9, 8 },
                    { 8, 4, 1 },
                    { 7, 8, 8 },
                    { 6, 1, 9 },
                    { 5, 1, 4 },
                    { 4, 4, 7 },
                    { 3, 10, 9 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Try to transmit the COM system, maybe it will transmit the redundant system!", "Karla.Corwin@yahoo.com", "Karla", "Corwin", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "If we override the feed, we can get to the FTP feed through the digital FTP feed!", "Floyd.Gleason77@hotmail.com", "Floyd", "Gleason", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't synthesize the circuit without synthesizing the redundant IB circuit!", "Lawrence90@hotmail.com", "Lawrence", "Kilback", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "You can't override the array without calculating the optical JSON array!", "Judith_Herzog3@yahoo.com", "Judith", "Herzog", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "The GB array is down, navigate the multi-byte array so we can navigate the GB array!", "Daryl_Kshlerin@hotmail.com", "Daryl", "Kshlerin", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "If we navigate the monitor, we can get to the JBOD monitor through the virtual JBOD monitor!", "Barbara.VonRueden0@gmail.com", "Barbara", "VonRueden", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "We need to program the bluetooth XML transmitter!", "Saul.Tillman34@yahoo.com", "Saul", "Tillman", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "The AI hard drive is down, connect the back-end hard drive so we can connect the AI hard drive!", "Preston.Padberg70@hotmail.com", "Preston", "Padberg", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "I'll transmit the open-source IB monitor, that should monitor the IB monitor!", "Maggie7@hotmail.com", "Maggie", "Denesik", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Email", "Name", "Surname", "Coins" },
                values: new object[] { "Use the optical SAS bandwidth, then you can compress the optical bandwidth!", "Abraham1@hotmail.com", "Abraham", "Kuphal", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassroom_StudentId",
                table: "StudentClassroom",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentArtifact_StudentId",
                table: "StudentArtifact",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorClassroom_MentorId",
                table: "MentorClassroom",
                column: "MentorId");
        }
    }
}
