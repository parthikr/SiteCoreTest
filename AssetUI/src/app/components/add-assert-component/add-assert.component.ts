import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges
} from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators
} from '@angular/forms';
import { IAssetData } from '../../interfaces/Iassert-data';
import { AssetAPIService } from '../../services/asset-api.service';

@Component({
  selector: 'app-add-assert',
  templateUrl: './add-assert.component.html',
  styleUrls: ['./add-assert.component.css']
})
export class AddAssertComponent implements OnInit, OnChanges {
  @Input() showForm: boolean = false;
  @Output() onCloseForm$: EventEmitter<boolean> = new EventEmitter();
  @Input() isUpdate: boolean = false;
  @Input() updatingData: IAssetData;
  form: FormGroup;
  constructor(private fb: FormBuilder, private api: AssetAPIService) {}

  ngOnInit() {
    this.buildForm();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.isUpdate && this.updatingData) {
      this.form.setValue({
        AssetId: this.updatingData.AssetId,
        file_name: this.updatingData.file_name,
        mime_type: this.updatingData.mime_type,
        created_by: this.updatingData.created_by,
        email: this.updatingData.email,
        country: this.updatingData.country,
        description: this.updatingData.description
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      AssetId: new FormControl(null),
      file_name: new FormControl('', [Validators.required]),
      mime_type: new FormControl('', [Validators.required]),
      created_by: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      country: new FormControl(''),
      description: new FormControl('')
    });
  }

  handleClose(): void {
    this.onCloseForm$.emit(false);
    this.form.reset();
  }

  saveChanges() {
    if (this.form.valid) {
      this.onSubmit();
    } else {
      this.form.markAllAsTouched();
    }
  }

  onSubmit() {
    const data = this.form.value;

    if (this.isUpdate) {
      //updating
      console.log('update', data);
      this.api.updateData(data).subscribe(res => {
        this.form.reset();
        this.isUpdate = false;
        this.onCloseForm$.emit(false);
      });
    } else {
      //save
      console.log('update', data);
      this.api.saveNewData(data).subscribe(res => {
        this.form.reset();
        this.isUpdate = false;
        this.onCloseForm$.emit(false);
      });
    }
  }
}
