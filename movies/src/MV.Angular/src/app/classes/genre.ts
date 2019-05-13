import { JsonObject, JsonProperty } from 'json2typescript';

@JsonObject('Genre')
export class Genre {

    @JsonProperty('id', Number, true)
    Id: number = undefined;

    @JsonProperty('name', String, true)
    Name: string = undefined;
}