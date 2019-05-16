import { JsonObject, JsonProperty } from 'json2typescript';
import { Movie } from './movie';
import { TMDBDate } from './tmdb_date';

@JsonObject('TMDBObj')
export class TMDBObj {

    @JsonProperty('results', [Movie], true)
    Results: Movie[] = undefined;

    @JsonProperty('page', Number, true)
    Page: number = undefined;

    @JsonProperty('total_Results', Number, true)
    Total_Results: number = undefined;
    
    @JsonProperty('dates', TMDBDate, true)
    Dates: TMDBDate = undefined;

    @JsonProperty('total_Pages', Number, true)
    Total_Pages: number = undefined;
}