class FormGenerator {
    constructor(jsonData, formId) {
        this.jsonData = jsonData;
        this.formContainer = document.getElementById(formId);
    }

    generate() {
        debugger;
        const form = document.createElement('form');

        this.jsonData.form.items.forEach(item => {
            const strategy = strategies[item.type];
            if (strategy) {
                strategy(item, form);
            } else {
                console.error(`Unsupported form element type: ${item.type}`);
            }
        });

        this.formContainer.appendChild(form);
    }
}

const strategies = {
    filler: (item, form) => appendElement('div', item.message, form),
    text: (item, form) => appendText('input', item, form),
    textarea: (item, form) => appendText('textarea', item, form),
    checkbox: (item, form) => appendCheckbox(item, form),
    button: (item, form) => appendButton(item, form),
    select: (item, form) => appendSelect(item, form),
    radio: (item, form) => appendRadio(item, form),
};

function appendText(type, item, parent) {
    const inputElement = document.createElement(type);

    inputElement.setAttribute('value', item.value || '');

    let res = appendCommon(item, inputElement);
    parent.appendChild(res);
}

function appendElement(tag, content, parent) {
    const element = document.createElement(tag);
    element.innerHTML = content;
    parent.appendChild(element);
}

function appendCheckbox(item, parent) {
    const inputElement = document.createElement('input');

    if(item.checked) {
        inputElement.setAttribute('checked', true);
    }

    let res = appendCommon(item, inputElement);
    parent.appendChild(res);
}

function appendButton(item, parent) {
    const button = document.createElement('button');
    button.innerHTML = item.text;
    parent.setAttribute('class', item.class || '');
    
    parent.appendChild(button);
}

function appendSelect(item, parent) {
    const element = document.createElement('select');

    element.setAttribute('value', item.value || '');

    let optionGen = optionGenerator(item, element);

    let res = appendCommon(item, element);
    parent.appendChild(res);
}

function optionGenerator (item, selectElement) {
    item.options.forEach(option => {
        const optionElement = document.createElement('option');
        optionElement.setAttribute('value', option.value || '');
        optionElement.innerHTML = option.text || '';

        if(item.selected) {
            element.setAttribute('selected', true);
        }
        selectElement.appendChild(optionElement);
    });
}

function appendRadio(item, parent) {

    item.items.forEach(radioItem => {
        const inputElement = document.createElement('input');

        inputElement.setAttribute('value', radioItem.value || '');
        inputElement.setAttribute('type', 'radio');

        if(radioItem.checked) {
            inputElement.setAttribute('checked', true);
        }

        let objectRadio = 
        {
            name: item.name,
            placeholder: item.placeholder,
            required: item.required,
            label: radioItem.label,
            class: item.class,
            disabled:  item.disabled
        };

        let res = appendCommon(objectRadio, inputElement);
        parent.appendChild(res);
    });
}

function appendCommon(item, inputElement) {
    inputElement.setAttribute('name', item.name);
    inputElement.setAttribute('placeholder', item.placeholder || '');
    inputElement.setAttribute('class', item.class || '');

    if(item.required) {
        inputElement.setAttribute('required', true);
    }
    if(item.disabled) {
        inputElement.setAttribute('disabled', true);
    }

    if(item.validationRules) {
        inputElement.setAttribute('type', item.validationRules.type);
    }

    if(item.label) {
        const labelElement = document.createElement("label");
        labelElement.innerHTML = item.label;

        labelElement.appendChild(inputElement);
        return labelElement;
    }
    else {
        return inputElement;
    }
}
