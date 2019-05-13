import { JsonObject, JsonProperty } from 'json2typescript';

@JsonObject('Movie')
export class Movie {

    @JsonProperty('id')
    Id: number = undefined;

    @JsonProperty('vote_Count')
    Vote_Count: number = undefined;

    @JsonProperty('video')
    Video: boolean = undefined;

    @JsonProperty('vote_Average')
    Vote_Average: number = undefined;

    @JsonProperty('title')
    Title: string = undefined;

    @JsonProperty('popularity')
    Popularity: number = undefined;

    @JsonProperty('poster_Path')
    Poster_Path: string = undefined;

    @JsonProperty('original_Language')
    Original_Language: string = undefined;

    @JsonProperty('original_Title')
    Original_Title: string = undefined;

    @JsonProperty('genre_Ids')
    Genre_Ids: number[] = undefined;

    @JsonProperty('backdrop_Path')
    Backdrop_Path: string = undefined;

    @JsonProperty('adult')
    Adult: boolean = undefined;

    @JsonProperty('overview')
    Overview: string = undefined;

    @JsonProperty('release_Date')
    Release_Date: Date = undefined;
}