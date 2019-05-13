import { JsonObject, JsonProperty } from 'json2typescript';
import { Movie } from './movie';
import { TMDBDate } from './tmdb_date';

@JsonObject('TMDBObj')
export class TMDBObj {

    @JsonProperty('result', [Movie])
    Results: Movie[] = undefined;

    @JsonProperty('page')
    Page: number = undefined;

    @JsonProperty('total_Results')
    Total_Results: number = undefined;
    
    @JsonProperty('dates', [TMDBDate])
    Dates: TMDBDate = undefined;

    @JsonProperty('total_Pages')
    Total_Pages: number = undefined;
}