import { Modal, Pressable, Text, View } from 'react-native';

interface ConfirmationModalProps {
  visible: boolean;
  title: string;
  message: string;
  confirmLabel: string;
  cancelLabel: string;
  onConfirm: () => void;
  onCancel: () => void;
  destructive?: boolean;
}

export const ConfirmationModal = ({
  visible,
  title,
  message,
  confirmLabel,
  cancelLabel,
  onConfirm,
  onCancel,
  destructive = false,
}: ConfirmationModalProps) => {
  return (
    <Modal
      visible={visible}
      transparent
      animationType="fade"
      onRequestClose={onCancel}
    >
      <Pressable
        className="flex-1 bg-black/50 items-center justify-center px-6"
        onPress={onCancel}
      >
        <Pressable
          className="bg-white rounded-2xl p-6 w-full max-w-sm"
          onPress={() => {}}
        >
          <Text className="text-lg font-bold text-slate-900 mb-2">{title}</Text>
          <Text className="text-sm text-slate-500 mb-6">{message}</Text>
          <View className="flex-row gap-3">
            <Pressable
              className="flex-1 h-11 rounded-xl border-2 border-slate-200 items-center justify-center active:bg-slate-50"
              onPress={onCancel}
            >
              <Text className="font-semibold text-slate-700">{cancelLabel}</Text>
            </Pressable>
            <Pressable
              className={`flex-1 h-11 rounded-xl items-center justify-center ${
                destructive ? 'bg-red-600 active:bg-red-700' : 'bg-blue-600 active:bg-blue-700'
              }`}
              onPress={onConfirm}
            >
              <Text className="font-semibold text-white">{confirmLabel}</Text>
            </Pressable>
          </View>
        </Pressable>
      </Pressable>
    </Modal>
  );
};
