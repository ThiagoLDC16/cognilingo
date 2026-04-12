import { Controller, type Control, type FieldValues, type Path } from 'react-hook-form';

import { Input, type InputProps } from './Input';

interface ControlledInputProps<T extends FieldValues> extends Omit<InputProps, 'value' | 'onChangeText'> {
  name: Path<T>;
  control: Control<T>;
}

export const ControlledInput = <T extends FieldValues>({
  name,
  control,
  ...props
}: ControlledInputProps<T>) => {
  return (
    <Controller
      name={name}
      control={control}
      render={({ field: { onChange, onBlur, value }, fieldState: { error } }) => (
        <Input
          onBlur={onBlur}
          onChangeText={onChange}
          value={value as string}
          error={error?.message}
          {...props}
        />
      )}
    />
  );
};
