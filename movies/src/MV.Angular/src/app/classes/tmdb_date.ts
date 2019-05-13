import { JsonObject, JsonProperty } from 'json2typescript';

@JsonObject('TMDBDate')
export class TMDBDate {

    @JsonProperty('maximum', Date, true)
    Maximum: Date = undefined;

    @JsonProperty('minimum', Date, true)
    Minimum: Date = undefined;
}