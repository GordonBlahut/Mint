# MINT - MaskableInt

A library that provides a custom type (**MaskableInt32**) that mimics the exact characteristics of Int32, while offering builtin obfuscation capabilities.

Its main purpose is to **leverage the obfuscation of plain IDs exposed publicly over the web** (e.g. WebAPIs, MVC etc.).

By allowing plain IDs to leak into the public space of the web, an application becomes crippled from a security perspective; the IDs can be manipulated and used for different malicious acts, like probing-by-incrementation - a technique in which a mal-intentioned user could tamper with URL parameters (IDs) by incrementing them and requesting new resources.


## Overview

The MaskableInt32 behaves identical to a 32 bit integer (In32) thus allowing the following operations to be performed seemingless:
- implicit instantiation/casting with Int32 values (int) and viceversa
    ```<language>
    MaskableIn32 value1 = 1;
    int value2 = value1;
    ```
- implicit operations with Int32 values (as well as with MaskableInt32 value): 
  - multiplicative and additive operators:
    ```<language>
    MaskableIn32 value1 = 1;
    MaskableIn32 value2 = 2;

    value1 * 1;
    value1 / 1;
    value1 % 2;
    2 + value1;    
    value1 / value2;
    value1 - value2;
    ```   
  - Relational operators:
    ```<language>
    MaskableIn32 value1 = 1;
    MaskableIn32 value2 = 2;

    value1 > 2;
    value1 <= value2;
    ```
  - Equality operators:
    ```<language>
    MaskableIn32 value1 = 1;
    MaskableIn32 value2 = 2;

    value1 == 2;
    value1 != value2;
    ```

In addition to the capabilities shared from its underlying Int32 type, the MaskableInt32 provides a new functionality: **obfuscation** and **deobfuscation** of its underlying value, using a salted hash.

This process can be triggered in several ways depending on its intended use:
1. Manual obfuscation/deobfuscation when used in regular contexts where there is no pipeline that can be used for triggering this process automatically.
2. Automatic obfuscation/deobfuscation when used in a web context (MVC/WebAPI) with support for Json and XML serialization.

*Observation:* The MaskableInt32 structure does not store internally the masked value, thus the name mask**able**.

## (De)obfuscation 

The obfuscation process is implemented using the [Hashids.net](http://hashids.org/net/) open source library, which generates short, unique, non-sequential ids from numbers, based on a Salt; 
The Mint library has a preconfigured Salt value as well as a preconfigured Alphabet (the characters used by the obfuscation process), however it can be overriden (and it is RECOMMENDED) on a global level by calling the following methods:

```<language>
MaskableInt32.SetObfuscationSalt("buysedf23d");
MaskableInt32.SetObfuscationAlphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");
```

Keep in mind that this values apply globally, thus dynamically changing them during the lifetime of the process, will cause previously obfuscated values to become invalid (non-deobfuscatable).

 

## Usage 

#### Manual process

In order to manually obfuscate/deobfuscate the value of a MaskableInt32 can be done by calling the corresponding methods:

- **Masking**:
    ```<language>
    MaskableInt32 value = 123;

    string maskedValue = inputValue.GetMaskedValue(); //results in a value of "MX12P"
    ```

    As it can be observed, the masked value is a unique string containing multiple characters from the configured Alphabet.

    *It is important to note that the first 2 characters are always the same ("MX"), and they are intentionally in order to allow for easy visual recognition of values obfuscated using the Mint library.*

- **Unmasking**
    ```<language>
    string maskedValue = "MX12P"
    MaskableInt32 value = MaskableInt32.GetUnmaskedValue(); //results in a value of 123
    ```
    The GetUnmaskedValue is a type method, thus it can only be called statically from the MaskableInt32 type.


#### Automatic process

The MaskableInt32 type comes with an out-of-box **TypeConverter** that is 
able to convert from string values that are either in clear format (unmasked -> plain integers) 
or in obfuscated format (masked integers).

On top of that, the Mint library also provides a JsonConverter 
able to serialize MaskableInt32 types, as well as deserialize json string 
that contain either in integer values or obfuscated representation of an integer value (masked integers).

In a Web API / MVC project, the obfuscation/deobfuscation process is triggered automatically, 
when using this struct as input parameter or response type for an 
API action method (either as standalone or included in other complex types).
 
The process is as follows:
  - For input params:
    - the input parameter value is expected as a string (that contains either a masked value, or a plain integer value)
    - the value is automatically unmasked by the WebApi/MVC through the means of custom TypeConverter/JsonConverter integrated into the Mint library (no configuration needed)
    - once inside the WebApi action method, the struct can be used as a plain old Int32 (its value having been already decoded)
  - For responses
    - if the value is used as return type (either directly or inside a complex type), it will automatically be masked by the WebApi before reaching the client, 
      again through the means of the custom TypeConverter/JsonConverter integrated into the Mint library

```<language>
[Route("users/{userId}")]
[HttpGet]
public IHttpActionResult GetUserById(MaskableInt userId)
{
    if (userId <= 0) //userId value has already been decoded and behaves as a regular Int32.
    {
        return BadRequest();
    }

    ...
    user.LocationId = 2;
    ...

    return Ok(user);
}
```

The request can look like this:
```<language>
GET /users/123    - Valid! The value is detected as being in plain format (int), thus no unmasking will be done.
GET /users/MX12P  - Valid! The value is detected as being in a masked format, thus will be unmasked automatically.
```

The response for a complex type that contains a MaskableInt32 property will look like this:
```<language>
class User
{
    MaskableInt32 UserId {get;set;}
    MaskableInt32 LocationId {get;set;}
    ...
}

{
    UserId: "MXQqN"
    LocationId
}
```

**Other examples**


```<language>
public class Value
{
    public MaskableInt32 Id { get; set; }
    public int DecodedId { get; set; }
    public string Name { get; set; }
    public IList<MaskableInt32> OtherIds { get; set; }
    public Value() { OtherIds = new List<MaskableInt32>(); }
}
```

- **GET with simple value from URI:**

    ```<language>
    [Route("simpleTypeFromUri/{id}")]
    [HttpGet]
    [ResponseType(typeof(Value))]
    public IHttpActionResult Get([FromUri]MaskableInt32 id)
    {
        return Ok(new Value { Id = id, DecodedId = id });
    }

    Request: GET /api/simpleTypeFromUri/QqN
    
    Response:
    {
      "id": "QqN",
      "decodedId": 123, //added just for demo purposes to see the decoded value
      "name": null,
      "otherIds": null
    }
    ```


- **GET with simple and complex values from URI:**

    ```<language>
    Route("simpleTypeFromUriAndComplexTypeFromUri")]
    [HttpGet]
    [ResponseType(typeof(Value))]
    public IHttpActionResult Get([FromUri]MaskableInt32 id, [FromUri]Value val)
    {
        return Ok(new Value { Id = val.Id, DecodedId = val.Id, Name = val.Name });
    }

    Request: GET /api/simpleTypeFromUriAndComplexTypeFromUri?id=QqN&val.id=QqN&val.name=test
    Request body: id = 123; val = {id=123, name=test };
    
    Response:
    {
      "id": "QqN",
      "decodedId": 123,
      "name": "test",
      "otherIds": null
    }
    ```

- **POST with simple value from URI and complex value from BODY:**

    ```<language>
    [Route("SimpleTypeFromUriAndComplexTypeFromBody/{id}")]
    [HttpPost]
    [ResponseType(typeof(HttpStatusCode))]
    public IHttpActionResult Post([FromUri]MaskableInt32 id, [FromBody]Value val)
    {
        val.DecodedId = id;
        return StatusCode(HttpStatusCode.Created);
    }

    Request: POST localhost:11223/api/SimpleTypeFromUriAndComplexTypeFromBody/32MW    
    {
      "id": "32MW",
      "decodedId": 0,
      "name": "test",
      "otherIds": [
        "QqN"
      ]
    }
    Request body: id = 12345; val = {id=12345, name=test , otherIds={123}};

    Response:
    {
      "id": "32MW",
      "decodedId": 12345,
      "name": "test",
      "otherIds": null
    }
    ```

**Constraints**

When using MaskableInt as route params, routes must not have parameter constraints. E.g.:
```<language>
[Route("{id: int"})] - ERROR: route will not be found in this case, because the action selector will detect that the provided value is a string and not an Integer value, thus skipping the action; action selection is done prior to model binding, thus the unmasking process has not occurred yet at this point.
```

```<language>
[Route("{id"})] - OK
```

### Instalation
The MaskableInt32 type can be used by installing **Mint nuget package** available [here](https://www.nuget.org/packages/Mint/).

```<language>
Install-Package Mint
```

The package has two dependencies:
1. Hashids.net - used for obfuscation.
2. Newtonsoft.Json - used for providing JsonSerialization support.