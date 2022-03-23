using net6_MongoDB;
using net6_MongoDB.Models;

MongoDb db = new MongoDb("TestDatabase");


//Insert Record

//var person = new Person
//{
//    FirstName = "Test",
//    LastName = "Test"
//};

//await db.InsertRecord("People", person);


//Get All Records

var records = await db.LoadRecords<Person>("People");

foreach (var record in records)
{
    Console.WriteLine($"{record.Id}: {record.FirstName} {record.LastName}");
    if (record.Addresses.Count != 0)
    {
        foreach (var address in record.Addresses)
        {
            Console.WriteLine($"  {address.StreetAddress} / {address.City}");
        }
    }
    Console.WriteLine();
}

// Get Person By Id

//var person = await db.LoadRecordById<Person>(
//    "People", 
//    new Guid("31b9dfe7-8430-4e44-bc92-3d258afc3969"));


// Update Record With Upsert

//var person = await db.LoadRecordById<Person>("People", new Guid("85e5fc75-913d-42e2-888d-c48838f44c78"));
//person.DateOfBirth = new DateTime(1990, 1, 1).ToUniversalTime();
//await db.UpsertRecord("People" ,person.Id, person);


//DeleteRecord

//await db.DeleteRecord<Person>("People", new Guid());

//Get Different Model From Database Record

//var records = await db.LoadRecords<Name>("People");

//foreach (var record in records)
//{
//    Console.WriteLine($"{record.Id}: {record.FirstName} {record.LastName}");
//    Console.WriteLine();
//}

Console.WriteLine("Done!");
Console.ReadLine();