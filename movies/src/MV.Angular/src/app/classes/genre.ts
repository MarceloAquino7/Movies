import { JsonObject, JsonProperty } from 'json2typescript';

@JsonObject('Genre')
export class Genre {

    @JsonProperty('id')
    Id: number = undefined;

    @JsonProperty('name')
    Name: string = undefined;
}