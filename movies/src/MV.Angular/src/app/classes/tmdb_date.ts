import { JsonObject, JsonProperty } from 'json2typescript';

@JsonObject('TMDBDate')
export class TMDBDate {

    @JsonProperty('maximum')
    Maximum: Date = undefined;

    @JsonProperty('minimum')
    Minimum: Date = undefined;
}