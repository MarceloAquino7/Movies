import { JsonObject, JsonProperty, Any } from 'json2typescript';

@JsonObject('MovieReviews')
export class MovieReviews {

    @JsonProperty('id', Any, true)
    Id: any = undefined;

    @JsonProperty('author', String, true)
    Author: string = undefined;

    @JsonProperty('content', String, true)
    Content: string = undefined;

    @JsonProperty('url', String, true)
    Url: string = undefined;
}