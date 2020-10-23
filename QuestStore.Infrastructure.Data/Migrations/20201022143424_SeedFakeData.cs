using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Infrastructure.Data.Migrations
{
    public partial class SeedFakeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Artifact",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name", "Quantity" },
                values: new object[,]
                {
                    { 10, 866, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "Ergonomic Fresh Pants", 7 },
                    { 9, 239, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, "Refined Frozen Cheese", null },
                    { 8, 192, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "Practical Fresh Pants", null },
                    { 3, 398, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "Fantastic Concrete Hat", 9 },
                    { 6, 752, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "Awesome Metal Cheese", null },
                    { 5, 293, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "Handmade Fresh Chips", 6 },
                    { 7, 584, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, "Awesome Plastic Ball", null },
                    { 4, 755, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, "Ergonomic Soft Tuna", null }
                });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Generic Wooden Ball", 147, "Extra" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Awesome Soft Sausages", 467 });

            migrationBuilder.InsertData(
                table: "Quest",
                columns: new[] { "Id", "Description", "Image", "Name", "Reward", "Type" },
                values: new object[,]
                {
                    { 10, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "Handcrafted Cotton Bacon", 56, "Basic" },
                    { 9, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, "Rustic Granite Sausages", 19, "Extra" },
                    { 7, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "Intelligent Plastic Tuna", 168, "Basic" },
                    { 6, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "Licensed Rubber Fish", 294, "Extra" },
                    { 5, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "Handmade Steel Tuna", 172, "Basic" },
                    { 4, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "Sleek Granite Towels", 274, "Extra" },
                    { 3, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "Awesome Concrete Chicken", 629, "Basic" },
                    { 8, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "Handcrafted Soft Soap", 325, "Extra" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AuthId", "Description", "Email", "Image", "Name", "Role", "Surname", "Coins" },
                values: new object[,]
                {
                    { 1, null, "Try to transmit the COM system, maybe it will transmit the redundant system!", "Karla.Corwin@yahoo.com", null, "Karla", "Student", "Corwin", 0 },
                    { 3, null, "You can't synthesize the circuit without synthesizing the redundant IB circuit!", "Lawrence90@hotmail.com", null, "Lawrence", "Student", "Kilback", 0 },
                    { 4, null, "You can't override the array without calculating the optical JSON array!", "Judith_Herzog3@yahoo.com", null, "Judith", "Student", "Herzog", 0 },
                    { 5, null, "The GB array is down, navigate the multi-byte array so we can navigate the GB array!", "Daryl_Kshlerin@hotmail.com", null, "Daryl", "Student", "Kshlerin", 0 },
                    { 6, null, "If we navigate the monitor, we can get to the JBOD monitor through the virtual JBOD monitor!", "Barbara.VonRueden0@gmail.com", null, "Barbara", "Student", "VonRueden", 0 },
                    { 7, null, "We need to program the bluetooth XML transmitter!", "Saul.Tillman34@yahoo.com", null, "Saul", "Student", "Tillman", 0 },
                    { 8, null, "The AI hard drive is down, connect the back-end hard drive so we can connect the AI hard drive!", "Preston.Padberg70@hotmail.com", null, "Preston", "Student", "Padberg", 0 },
                    { 9, null, "I'll transmit the open-source IB monitor, that should monitor the IB monitor!", "Maggie7@hotmail.com", null, "Maggie", "Student", "Denesik", 0 },
                    { 10, null, "Use the optical SAS bandwidth, then you can compress the optical bandwidth!", "Abraham1@hotmail.com", null, "Abraham", "Student", "Kuphal", 0 },
                    { 2, null, "If we override the feed, we can get to the FTP feed through the digital FTP feed!", "Floyd.Gleason77@hotmail.com", null, "Floyd", "Student", "Gleason", 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentArtifact",
                columns: new[] { "Id", "ArtifactId", "StudentId" },
                values: new object[,]
                {
                    { 8, 4, 1 },
                    { 1, 7, 2 },
                    { 10, 1, 3 },
                    { 5, 1, 4 },
                    { 4, 4, 7 },
                    { 9, 3, 7 },
                    { 2, 9, 8 },
                    { 7, 8, 8 },
                    { 3, 10, 9 },
                    { 6, 1, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 10);

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

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 50, null, "Private mentoring" });

            migrationBuilder.UpdateData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description", "Name", "Quantity" },
                values: new object[] { 300, null, "You can spend a day in home office", null });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Reward", "Type" },
                values: new object[] { null, "Finishing two-week assignment", 100, "Basic" });

            migrationBuilder.UpdateData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Reward" },
                values: new object[] { null, "Passing a Checkpoint", 500 });
        }
    }
}
