import { JsonObject, JsonProperty } from 'json2typescript';
import { Crew } from './crew';
import { Cast } from './cast';

@JsonObject('Credits')
export class Credits {

    @JsonProperty('id', Number, true)
    Id: number = undefined;

    @JsonProperty('cast', [Cast], true)
    Cast: Cast[] = undefined;

    @JsonProperty('crew', [Crew], true)
    Crew: Crew[] = undefined;
}