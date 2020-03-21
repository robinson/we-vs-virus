import { SelectItem } from './select-item.model';
import { InputByDropBox } from './input-by-drop-box.model';

export interface BottomSheetDialogData {
    title: string;
    text: string;
    acceptText?: string;
    declineText?: string;
    inputFieldValue?: string;
    inputLabel?: string;
    acceptIcon?: string;
    acceptCallback: () => {};
    declineCallback: () => {};
    extra?: any;
    dropBoxOptions?: SelectItem[];
    inputsByDropBox?: InputByDropBox[];
    inputByDropBoxLabel?: string;
}
