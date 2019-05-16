import { JsonObject, JsonProperty, Any } from 'json2typescript';
import { Genre } from './genre';

@JsonObject('Movie')
export class Movie {

    @JsonProperty('id', Any, true)
    Id: any = undefined;

    @JsonProperty('vote_Count', Number, true)
    Vote_Count: number = undefined;

    @JsonProperty('video', Boolean, true)
    Video: boolean = undefined;

    @JsonProperty('vote_Average', Number, true)
    Vote_Average: number = undefined;

    @JsonProperty('title', String, true)
    Title: string = undefined;

    @JsonProperty('popularity', Number, true)
    Popularity: number = undefined;

    @JsonProperty('poster_Path', String, true)
    Poster_Path: string = undefined;

    @JsonProperty('original_Language', String, true)
    Original_Language: string = undefined;

    @JsonProperty('original_Title', String, true)
    Original_Title: string = undefined;

    @JsonProperty('homepage', String, true)
    Homepage: string = undefined;

    @JsonProperty('tagline', String, true)
    Tagline:string = undefined;

    @JsonProperty('genre_Ids', [Number], true)
    Genre_Ids: number[] = undefined;

    @JsonProperty('genres', [Genre], true)
    Genres: Genre[] = undefined;

    @JsonProperty('backdrop_Path', String, true)
    Backdrop_Path: string = undefined;

    @JsonProperty('adult', Boolean, true)
    Adult: boolean = undefined;

    @JsonProperty('overview', String, true)
    Overview: string = undefined;

    @JsonProperty('release_Date', String, true)
    Release_Date: string = undefined;
}