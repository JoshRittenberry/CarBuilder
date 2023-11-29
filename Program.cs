List<PaintColor> paintColors = new List<PaintColor>()
{
    new PaintColor()
    {
        Id = 1,
        Price = 200,
        Color = "Silver"
    },
    new PaintColor()
    {
        Id = 2,
        Price = 250,
        Color = "Midnight Blue"
    },
    new PaintColor()
    {
        Id = 3,
        Price = 275,
        Color = "Firebrick Red"
    },
    new PaintColor()
    {
        Id = 4,
        Price = 220,
        Color = "Spring Green"
    }
};
List<Interior> interiors = new List<Interior>()
{
    new Interior()
    {
        Id = 1,
        Price = 100,
        Material = "Beige Fabric"
    },
    new Interior()
    {
        Id = 2,
        Price = 100,
        Material = "Charcoal Fabric"
    },
    new Interior()
    {
        Id = 3,
        Price = 300,
        Material = "White Leather"
    },
    new Interior()
    {
        Id = 4,
        Price = 300,
        Material = "Black Leather"
    }
};
List<Technology> technologies = new List<Technology>()
{
    new Technology()
    {
        Id = 1,
        Price = 100,
        Package = "Basic Package"
    },
    new Technology()
    {
        Id = 2,
        Price = 300,
        Package = "Navigation Package"
    },
    new Technology()
    {
        Id = 3,
        Price = 250,
        Package = "Visibility Package"
    },
    new Technology()
    {
        Id = 4,
        Price = 500,
        Package = "Ultra Package"
    }
};
List<Wheel> wheels = new List<Wheel>()
{
    new Wheel()
    {
        Id = 1,
        Price = 400,
        Style = "17-inch Pair Radial"
    },
    new Wheel()
    {
        Id = 2,
        Price = 450,
        Style = "17-inch Pair Radial Black"
    },
    new Wheel()
    {
        Id = 3,
        Price = 500,
        Style = "18-inch Pair Spoke Silver"
    },
    new Wheel()
    {
        Id = 4,
        Price = 550,
        Style = "18-inch Pair Spoke Black"
    }
};
List<Order> orders = new List<Order>()
{
    new Order
    {
        Id = 1,
        PaintId = 2,
        InteriorId = 1,
        TechnologyId = 2,
        WheelId = 2,
        Timestamp = new DateTime(2021, 1, 2)
    },
    new Order
    {
        Id = 2,
        PaintId = 4,
        InteriorId = 3,
        TechnologyId = 4,
        WheelId = 4,
        Timestamp = new DateTime(2021, 1, 10)
    },
    new Order
    {
        Id = 3,
        PaintId = 4,
        InteriorId = 4,
        TechnologyId = 4,
        WheelId = 4,
        Timestamp = new DateTime(2021, 6, 20)
    },
    new Order
    {
        Id = 4,
        PaintId = 2,
        InteriorId = 2,
        TechnologyId = 1,
        WheelId = 1,
        Timestamp = new DateTime(2022, 8, 3)
    },
    new Order
    {
        Id = 5,
        PaintId = 3,
        InteriorId = 1,
        TechnologyId = 2,
        WheelId = 1,
        Timestamp = new DateTime(2021, 12, 7)
    }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();