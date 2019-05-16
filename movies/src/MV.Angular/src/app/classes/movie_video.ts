import { JsonObject, JsonProperty, Any } from 'json2typescript';

@JsonObject('MovieVideo')
export class MovieVideo {

    @JsonProperty('id', Any, true)
    Id: any = undefined;

    @JsonProperty('iso_639_1', String, true)
    Iso_639_1: string = undefined;

    @JsonProperty('iso_3166_1', String, true)
    Iso_3166_1: string = undefined;

    @JsonProperty('key', String, true)
    Key: string = undefined;

    @JsonProperty('name', String, true)
    Name: string = undefined;

    @JsonProperty('site', String, true)
    Site: string = undefined;

    @JsonProperty('size', Number, true)
    Size: number = undefined;

    @JsonProperty('type', String, true)
    Type: string = undefined;
}