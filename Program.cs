List<Vehicle> vehicles = new List<Vehicle>()
{
    new Vehicle()
    {
        Id = 1,
        Type = "Car"
    },
    new Vehicle()
    {
        Id = 2,
        Type = "SUV"
    },
    new Vehicle()
    {
        Id = 3,
        Type = "Truck"
    }
};
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
        VehicleId = 1,
        PaintId = 2,
        InteriorId = 1,
        TechnologyId = 2,
        WheelId = 2,
        Timestamp = new DateTime(2021, 1, 2)
    },
    new Order
    {
        Id = 2,
        VehicleId = 3,
        PaintId = 4,
        InteriorId = 3,
        TechnologyId = 4,
        WheelId = 4,
        Timestamp = new DateTime(2021, 1, 10)
    },
    new Order
    {
        Id = 3,
        VehicleId = 3,
        PaintId = 4,
        InteriorId = 4,
        TechnologyId = 4,
        WheelId = 4,
        Timestamp = new DateTime(2021, 6, 20)
    },
    new Order
    {
        Id = 4,
        VehicleId = 1,
        PaintId = 2,
        InteriorId = 2,
        TechnologyId = 1,
        WheelId = 1,
        Timestamp = new DateTime(2022, 8, 3)
    },
    new Order
    {
        Id = 5,
        VehicleId = 2,
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
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

// Get Methods
app.MapGet("/vehicles", () =>
{
    return vehicles.Select(v => new VehicleDTO
    {
        Id = v.Id,
        Type = v.Type
    });
});

app.MapGet("/paintcolors", () =>
{
    return paintColors.Select(p => new PaintColorDTO
    {
        Id = p.Id,
        Price = p.Price,
        Color = p.Color
    });
});

app.MapGet("/interiors", () =>
{
    return interiors.Select(i => new InteriorDTO
    {
        Id = i.Id,
        Price = i.Price,
        Material = i.Material
    });
});

app.MapGet("/technologies", () =>
{
    return technologies.Select(t => new TechnologyDTO
    {
        Id = t.Id,
        Price = t.Price,
        Package = t.Package
    });
});

app.MapGet("/wheels", () =>
{
    return wheels.Select(w => new WheelDTO
    {
        Id = w.Id,
        Price = w.Price,
        Style = w.Style
    });
});

app.MapGet("/orders", () =>
{
    return orders.Select(o =>
    {
        var vehicle = vehicles.FirstOrDefault(v => v.Id == o.VehicleId);
        var wheel = wheels.FirstOrDefault(w => w.Id == o.WheelId);
        var technology = technologies.FirstOrDefault(t => t.Id == o.TechnologyId);
        var paintColor = paintColors.FirstOrDefault(p => p.Id == o.PaintId);
        var interior = interiors.FirstOrDefault(i => i.Id == o.InteriorId);

        return new OrderDTO
        {
            Id = o.Id,
            Timestamp = o.Timestamp,
            VehicleId = o.VehicleId,
            Vehicle = vehicle != null ? new VehicleDTO
            {
                Id = vehicle.Id,
                Type = vehicle.Type
            } : null,
            WheelId = o.WheelId,
            Wheel = wheel != null ? new WheelDTO
            {
                Id = wheel.Id,
                Price = wheel.Price,
                Style = wheel.Style
            } : null,
            TechnologyId = o.TechnologyId,
            Technology = technology != null ? new TechnologyDTO
            {
                Id = technology.Id,
                Price = technology.Price,
                Package = technology.Package
            } : null,
            PaintId = o.PaintId,
            Paint = paintColor != null ? new PaintColorDTO
            {
                Id = paintColor.Id,
                Price = paintColor.Price,
                Color = paintColor.Color
            } : null,
            InteriorId = o.InteriorId,
            Interior = interior != null ? new InteriorDTO
            {
                Id = interior.Id,
                Price = interior.Price,
                Material = interior.Material
            } : null
        };
    });
});

app.MapGet("/orders/{id}", (int id) =>
{
    Order order = orders.FirstOrDefault(o => o.Id == id);
    if (order == null)
    {
        return Results.NotFound();
    }

    Vehicle vehicle = vehicles.FirstOrDefault(v => v.Id == order.VehicleId);
    Wheel wheel = wheels.FirstOrDefault(w => w.Id == order.WheelId);
    Technology technology = technologies.FirstOrDefault(t => t.Id == order.TechnologyId);
    PaintColor paintColor = paintColors.FirstOrDefault(p => p.Id == order.PaintId);
    Interior interior = interiors.FirstOrDefault(i => i.Id == order.InteriorId);

    return Results.Ok(new OrderDTO
    {
        Id = order.Id,
        Timestamp = order.Timestamp,
        VehicleId = order.VehicleId,
        Vehicle = vehicle != null ? new VehicleDTO
        {
            Id = vehicle.Id,
            Type = vehicle.Type
        } : null,
        WheelId = order.WheelId,
        Wheel = wheel != null ? new WheelDTO
        {
            Id = wheel.Id,
            Price = wheel.Price,
            Style = wheel.Style
        } : null,
        TechnologyId = order.TechnologyId,
        Technology = technology != null ? new TechnologyDTO
        {
            Id = technology.Id,
            Price = technology.Price,
            Package = technology.Package
        } : null,
        PaintId = order.PaintId,
        Paint = paintColor != null ? new PaintColorDTO
        {
            Id = paintColor.Id,
            Price = paintColor.Price,
            Color = paintColor.Color
        } : null,
        InteriorId = order.InteriorId,
        Interior = interior != null ? new InteriorDTO
        {
            Id = interior.Id,
            Price = interior.Price,
            Material = interior.Material
        } : null
    });
});

// Post Method
app.MapPost("/orders", (Order order) =>
{
    order.Id = orders.Max(o => o.Id) + 1;
    orders.Add(order);

    Wheel wheel = wheels.FirstOrDefault(w => w.Id == order.WheelId);
    Technology technology = technologies.FirstOrDefault(t => t.Id == order.TechnologyId);
    PaintColor paintColor = paintColors.FirstOrDefault(p => p.Id == order.PaintId);
    Interior interior = interiors.FirstOrDefault(i => i.Id == order.InteriorId);

    if (wheel == null || technology == null || paintColor == null || interior == null)
    {
        return Results.BadRequest();
    }

    return Results.Created($"/orders/{order.Id}", new OrderDTO
    {
        Id = order.Id,
        Timestamp = DateTime.Now,
        WheelId = order.WheelId,
        Wheel = wheel != null ? new WheelDTO
        {
            Id = wheel.Id,
            Price = wheel.Price,
            Style = wheel.Style
        } : null,
        TechnologyId = order.TechnologyId,
        Technology = technology != null ? new TechnologyDTO
        {
            Id = technology.Id,
            Price = technology.Price,
            Package = technology.Package
        } : null,
        PaintId = order.PaintId,
        Paint = paintColor != null ? new PaintColorDTO
        {
            Id = paintColor.Id,
            Price = paintColor.Price,
            Color = paintColor.Color
        } : null,
        InteriorId = order.InteriorId,
        Interior = interior != null ? new InteriorDTO
        {
            Id = interior.Id,
            Price = interior.Price,
            Material = interior.Material
        } : null
    });
});

app.Run();