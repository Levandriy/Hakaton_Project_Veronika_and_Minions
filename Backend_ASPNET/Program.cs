using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Backend_ASPNET.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//������ ������, ������� ����� ��-�� ������������ � ���� ������� ������.
//���� - ������� ���, ����� ������ ����, ��������� �� ����� � ������� �������� ������.
//���� ����� �� ����, ������������� ��������� ��� ����� ����� �� ����
app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    if (request.Path == "/api/user")
    {
        var responseText = "������������ ������";   // ���������� ��������� �� ���������
        if (request.HasJsonContentType())
        {
            // ���������� ��������� ������������/��������������
            var jsonoptions = new JsonSerializerOptions();
            // ��������� ��������� ���� json � ������ ���� Person
            jsonoptions.Converters.Add(new PersonConverter());
            // ������������� ������ � ������� ���������� PersonConverter
            var person = await request.ReadFromJsonAsync<Person>(jsonoptions);
            if (person != null) responseText = $"Name: {person.Name}  Age: {person.Age}";
        }
        await response.WriteAsJsonAsync(new { text = responseText });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Views/Home/index.cshtml");
    }
});

app.Run();
//������ - �������� �� ����� �� �������
public record Person(string Name, int Age);
//json converter - ������ ����
public class PersonConverter : JsonConverter<Person>
{
    public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var personName = "Undefined";
        var personAge = 0;
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                switch (propertyName?.ToLower())
                {
                    // ���� �������� age � ��� �������� �����
                    case "age" when reader.TokenType == JsonTokenType.Number:
                        personAge = reader.GetInt32();  // ��������� ����� �� json
                        break;
                    // ���� �������� age � ��� �������� ������
                    case "age" when reader.TokenType == JsonTokenType.String:
                        string? stringValue = reader.GetString();
                        // �������� �������������� ������ � �����
                        if (int.TryParse(stringValue, out int value))
                        {
                            personAge = value;
                        }
                        break;
                    case "name":    // ���� �������� Name/name
                        string? name = reader.GetString();
                        if (name != null)
                            personName = name;
                        break;
                }
            }
        }
        return new Person(personName, personAge);
    }
    // ����������� ������ Person � json
    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name", person.Name);
        writer.WriteNumber("age", person.Age);

        writer.WriteEndObject();
    }
}

