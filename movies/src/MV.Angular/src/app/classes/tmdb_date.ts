import { JsonObject, JsonProperty } from 'json2typescript';

@JsonObject('TMDBDate')
export class TMDBDate {

    @JsonProperty('maximum', String, true)
    Maximum: string = undefined;

    @JsonProperty('minimum', String, true)
    Minimum: string = undefined;
}